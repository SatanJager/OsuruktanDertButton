using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuruktanDertButton
{
    public enum AppTheme
    {
        RetroClassic,
        Dark,
        Light,
        Matrix,
        WindowsXpLuna,
        AmberTerminal,
        Vaporwave,
        MsnMessenger,
    }
    public class ThemeColors
    {
        public required Color FormBackColor {  get; init; }
        public required Color LabelForeColor { get; init; }
        public required Color TextBoxBackColor { get; init; }
        public required Color TextBoxForeColor { get; init; }
        public required Color ButtonFaceLight { get; init; }
        public required Color ButtonFaceDark { get; init; }
        public required Color ButtonTextColor { get; init; }
        public required Color SecondaryButtonBackColor { get; init; }
        public required Color SecondaryButtonTextColor { get; init; }
        public required Color DangerButtonBackColor { get; init; }
        public required Color DangerButtonTextColor { get; init; }

    }
    public static class Themes
    {
        public static readonly Dictionary<AppTheme, ThemeColors> Palette = new()
        {
            [AppTheme.RetroClassic] = new ThemeColors
            {
                FormBackColor = Color.Cornsilk,
                LabelForeColor = Color.Black,
                TextBoxBackColor = Color.White,
                TextBoxForeColor = Color.Black,
                ButtonFaceLight = Color.IndianRed,
                ButtonFaceDark = Color.Firebrick,
                ButtonTextColor = Color.White,
                SecondaryButtonBackColor = Color.Gainsboro,
                SecondaryButtonTextColor = Color.Black,
                DangerButtonBackColor = Color.Firebrick,
                DangerButtonTextColor = Color.White,
            },
            [AppTheme.Dark] = new ThemeColors
            {
                FormBackColor = Color.FromArgb(32, 32, 32),
                LabelForeColor = Color.Gainsboro,
                TextBoxBackColor = Color.FromArgb(50, 50, 50),
                TextBoxForeColor = Color.White,
                ButtonFaceLight = Color.FromArgb(200, 60, 60),
                ButtonFaceDark = Color.FromArgb(120, 20, 20),
                ButtonTextColor = Color.White,
                SecondaryButtonBackColor = Color.FromArgb(70, 70, 70),
                SecondaryButtonTextColor = Color.White,
                DangerButtonBackColor = Color.FromArgb(120, 20, 20),
                DangerButtonTextColor = Color.White,
            },
            [AppTheme.Light] = new ThemeColors
            {
                FormBackColor = Color.White,
                LabelForeColor = Color.Black,
                TextBoxBackColor = Color.WhiteSmoke,
                TextBoxForeColor = Color.Black,
                ButtonFaceLight = Color.LightCoral,
                ButtonFaceDark = Color.Crimson,
                ButtonTextColor = Color.White,
                SecondaryButtonBackColor = Color.WhiteSmoke,
                SecondaryButtonTextColor = Color.Black,
                DangerButtonBackColor = Color.Crimson,
                DangerButtonTextColor = Color.White,
            },
            [AppTheme.Matrix] = new ThemeColors
            {
                FormBackColor = Color.Black,
                LabelForeColor = Color.FromArgb(0, 255, 70),
                TextBoxBackColor = Color.FromArgb(0, 15, 0),
                TextBoxForeColor = Color.FromArgb(0, 255, 70),
                ButtonFaceLight = Color.FromArgb(0, 180, 70),
                ButtonFaceDark = Color.FromArgb(0, 90, 30),
                ButtonTextColor = Color.FromArgb(230, 255, 230),
                SecondaryButtonBackColor = Color.FromArgb(20, 40, 20),
                SecondaryButtonTextColor = Color.FromArgb(0, 255, 70),
                DangerButtonBackColor = Color.FromArgb(120, 20,20),
                DangerButtonTextColor = Color.FromArgb(255, 200, 200),
            },
            [AppTheme.WindowsXpLuna] = new ThemeColors
            {
                FormBackColor = Color.FromArgb(214, 233, 253),
                LabelForeColor = Color.FromArgb(0, 51, 102),
                TextBoxBackColor = Color.White,
                TextBoxForeColor = Color.Black,
                //ButtonFaceLight = Color.FromArgb(126, 200, 80), // Yeşil başlat buttonu esintisi
                //ButtonFaceDark = Color.FromArgb(58, 142, 36),
                //ButtonTextColor = Color.White,
                ButtonFaceLight = Color.FromArgb(241, 241, 241),
                ButtonFaceDark = Color.FromArgb(172, 172, 172),
                ButtonTextColor = Color.Black,
                SecondaryButtonBackColor = Color.FromArgb(49, 106, 197),
                SecondaryButtonTextColor = Color.White,
                DangerButtonBackColor = Color.FromArgb(196, 44, 44),
                DangerButtonTextColor = Color.White,
            },
            [AppTheme.AmberTerminal] = new ThemeColors
            {
                FormBackColor = Color.FromArgb(15, 10, 0),
                LabelForeColor = Color.FromArgb(255, 176, 0),
                TextBoxBackColor = Color.FromArgb(20, 13, 0),
                TextBoxForeColor = Color.FromArgb(255, 191, 0),
                ButtonFaceLight = Color.FromArgb(255, 170, 0),
                ButtonFaceDark = Color.FromArgb(120, 70, 0),
                ButtonTextColor = Color.FromArgb(20, 10, 0),
                SecondaryButtonBackColor = Color.FromArgb(45, 33, 10),
                SecondaryButtonTextColor = Color.FromArgb(255, 176, 0),
                DangerButtonBackColor = Color.FromArgb(180, 60, 0),
                DangerButtonTextColor = Color.FromArgb(20, 10, 0),
            },
            [AppTheme.Vaporwave] = new ThemeColors
            {
                FormBackColor = Color.FromArgb(40, 20, 60),
                LabelForeColor = Color.FromArgb(255, 170, 230),
                TextBoxBackColor = Color.FromArgb(60, 30, 90),
                TextBoxForeColor = Color.FromArgb(0, 255, 234),
                ButtonFaceLight = Color.FromArgb(255, 110, 199),
                ButtonFaceDark = Color.FromArgb(123, 47, 247),
                ButtonTextColor = Color.White,
                SecondaryButtonBackColor = Color.FromArgb(0, 200, 210),
                SecondaryButtonTextColor = Color.FromArgb(30, 10, 50),
                DangerButtonBackColor = Color.FromArgb(255, 60, 120),
                DangerButtonTextColor = Color.White,
            },
            [AppTheme.MsnMessenger] = new ThemeColors
            {
                FormBackColor = Color.FromArgb(237, 246, 255),
                LabelForeColor = Color.FromArgb(0, 84, 164),
                TextBoxBackColor = Color.White,
                TextBoxForeColor = Color.Black,
                ButtonFaceLight = Color.FromArgb(117, 185, 255),
                ButtonFaceDark = Color.FromArgb(0, 120, 215),
                ButtonTextColor = Color.White,
                SecondaryButtonBackColor = Color.FromArgb(222, 235, 250),
                SecondaryButtonTextColor = Color.FromArgb(0, 84, 164),
                DangerButtonBackColor = Color.FromArgb(205, 60, 60),
                DangerButtonTextColor = Color.White,
            },
        };

        public static AppTheme CurrentTheme { get; private set; } = AppTheme.RetroClassic;

        public static event EventHandler? ThemeChanged;

        public static void SetTheme(AppTheme theme)
        {
            if (CurrentTheme == theme)
                return;

            CurrentTheme = theme;
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }
        public static ThemeColors Current => Palette[CurrentTheme];

    }
}
