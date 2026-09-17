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
