using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace OsuruktanDertButton
{
    public class BigRedButton : Control
    {
        private const int MaxPressOffset = 6;
        private const float AnimationSpeed = 1.5f;

        private float _currentOffset = 0f;
        private float _targetOffset = 0f;
        private bool _isMouseDown = false;
        private readonly System.Windows.Forms.Timer _animationTimer;
        public Color LightFaceColor { get; set; } = Color.IndianRed;
        public Color DarkFaceColor { get; set; } = Color.Firebrick;

        public BigRedButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            _animationTimer = new System.Windows.Forms.Timer { Interval = 15 };
            _animationTimer.Tick += OnAnimationTick;
        }
        private void ApplyCircularRegion()
        {
            var path = new GraphicsPath();
            path.AddEllipse(0, 0, Width, Height);
            Region = new Region(path);
        }
        //Resize'ın override'ı yani button boyutlandırması
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyCircularRegion();
        }
        //Fare olaylarını overrideları
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isMouseDown = true;
            _targetOffset = MaxPressOffset;
            _animationTimer.Start();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isMouseDown = false;
            _targetOffset = 0f;
            _animationTimer.Start();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_isMouseDown) 
            {
                _isMouseDown = false;
                _targetOffset = 0f;
                _animationTimer.Start();
            }
        }
        private void OnAnimationTick(object? sender, EventArgs e)
        {
            if (Math.Abs(_currentOffset - _targetOffset) < 0.1f)  
                //mevcut konum ile hedef konum arasındaki fark neredeyse sıfırsa (0.1 piksilden az), "artık vardık" diyoruz. Neden tam == _targetOffset diye eşitlik kontrol etmiyoruz? Çünkü _currentOffset += direction * AnimationSpeed işlemiyle ilerlerken, ondalıklı sayı toplamaları (float) çoğu zaman hedefe tam olarak denk gelmez, hafifçe aşabilir veya altında kalabilir (kayan nokta hassasiyeti / floating point precision meselesi) — o yüzden "yeterince yakın mı" diye bir tolerans (0.1f) ile kontrol ediyoruz.
            {
                _currentOffset = _targetOffset;  //ile son ufak farkı da temizleyip tam hedefe oturtuyoruz
                _animationTimer.Stop();  //ile de artık animasyon bittiği için Timer'ı durduruyoruz (gereksiz yere CPU'yu meşgul etmesin diye — hedefe ulaşınca tetiklenmeye devam etmesinin bir anlamı yok).
            }
            else
            {
                var direction = _targetOffset > _currentOffset ? 1f : -1f;  //hedefe doğru hangi yönde gitmemiz gerektiğini buluyoruz. Hedef mevcut konumdan büyükse (yani daha çok batması gerekiyorsa) 1 (ileri/aşağı), küçükse -1 (geri/yukarı) yönünde ilerliyoruz.
                _currentOffset += direction * AnimationSpeed; //mevcut konumu, o yönde AnimationSpeed (1.5 piksel) kadar kaydırıyoruz. Bu satır her Tick'te (saniyede ~66 kez) çağrıldığı için, göz gerçek zamanlı yumuşak bir hareket olarak algılıyor — aslında arka planda küçük küçük "zıplamalar" oluyor ama insan gözü bu kadar hızlı değişimi süreklilik olarak yorumluyor.
            }

            Invalidate();  
            //Windows'a "bu kontrolü yeniden çizmen lazım" diyor — bu çağrı olmadan, _currentOffset değişse bile ekranda hiçbir şey görünmez, çünkü kontrolün görsel hali sadece OnPaint metodu çalıştığında güncellenir, Invalidate() de o OnPaint'in tekrar çalışmasını tetikleyen şey. Yani her Tick'te: konumu hesapla → yeniden çizilmesini iste → (Windows arka planda) OnPaint'i çağır.
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var baseBrush = new SolidBrush(Color.FromArgb(120, 0, 0)))
            {
                g.FillEllipse(baseBrush, 0, 0, Width, Height);
            }

            int faceHeight = Height - MaxPressOffset;
            var faceRect = new Rectangle(0, (int)_currentOffset, Width, faceHeight);

            using (var faceBrush = new LinearGradientBrush(faceRect, LightFaceColor, DarkFaceColor, LinearGradientMode.ForwardDiagonal))
            {
                g.FillEllipse(faceBrush, faceRect);
            }

            TextRenderer.DrawText(
                g,
                Text,
                Font,
                faceRect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
