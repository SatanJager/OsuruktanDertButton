# Osuruktan Dert Button 💨

2000'lerin o meşhur "işe yaramaz ama sevimli masaüstü programlarına bir saygı duruşu. Derdinizi yazun, "Çözüm" butonuna basın - derdinizi anında (ve haklı olarak) önemsiz ilan etsin.

> 📋 Bu proje Jira üzerinden epic/story bazlı olarak takip edilmektedir. Geliştirme süreci sprint'ler halinde ilerlemektedir.

---

🇹🇷 Türkçe | [🇬🇧 English](#english) | [🇩🇪 Deutsch](#deutsch)

## Ne işe yarar?

- Bir metin kutusuna derdinizi/sorununuzu yazarsınız.
- **Çözüm** butonuna basarsınız.
- Kutu temizlenir, ekranda şu mesaj çıkar: *"Derdiniz çok osuruktan bulundu. Çözüm gerekmiyor."*
- Dert kaybolmaz - sessizce kaydedilir. **Önceki Dertlerim** penceresinden geçmişe göz atabilirisiniz.

## Özellikler

- 🌍 **3 dil desteği**: Türkçe, English, Deutsch
- 📝 **Geçmiş kaydı**: Her dert, tarih/saat damgasıyla birlikte saklanır
- 🔒 **Kullanıcı özel depolama**: Dertler `%APPDATA%\OsuruktanDertButton\complaints.txt` içinde tutulur — program dosyası paylaşılsa bile dertler o kullanıcıya özel kalır, başkasına gitmez
- 🗑️ **Geçmişi temizleme**: Tek tıkla tüm kayıtları silme

## Teknoloji

- **C# / .NET 8**
- **Windows Forms (Winforms)**

## Nasıl çalışır?

1. Bu repoyu klonlayın veya indirin.
2. Visiual Studio ile `OsuruktanDertButton.csproj` dosyasını açın (.NET 8 SDK gereklidir).
3. `F5` ile çalıştırın.

## Proje Yapısı

| Dosya | Açıklama |
| --- | --- |
| `Program.cs` | Uygulamanın giriş noktası |
| `MainForm.cs` | Ana pencere — dert giriş ekranı, dil seçici |
| `HistoryForm.cs` | "Önceki Dertlerim" penceresi |
| `Localization.cs` | TR/EN/DE metin çevirileri |
| `ComplaintStore.cs` | Dertlerin diske yazılması/okunması |

## Yol Haritası

Proje aşağıdaki epic'ler halinde geliştiriliyor:

- [x] Temel UI ve dil desteği
- [x] Kayıt mekanizması (dert kaydetme, geçmiş görüntüleme, temizleme)
- [ ] Cilalama (yuvarlak animasyonlu "Çözüm" butonu, kullanılabilirlik iyileştirmeleri
- [ ] Ekstra özellikler (versiyonlama, ikon, sistem tepsisine küçütme, ses efektleri)

## Katkıda Bulunma

Bu bir öğrenme/eğlence projesi olarak geliştiriliyor. Öneri ve geri bildirimler için issue açabilirsiniz.

## Lisans

Henüz belirlenmedi.
