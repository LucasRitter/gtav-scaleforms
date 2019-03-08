extern alias rph1;
using rph1::Rage;

namespace LucasRitter.Scaleforms
{
    public class Rgb
    {
        public byte Red = 0;
        public byte Green = 0;
        public byte Blue = 0;
        
        public Rgb() {}

        public Rgb(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public Rgb(int hex)
        {
            this.Red = (byte)((hex & 0xff0000) >> 16);
            this.Green = (byte)((hex & 0xff00) >> 8);
            this.Blue = (byte)(hex & 0xff);
        }

        public void SetRgb(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override string ToString() => $"red: {this.Red}, green: {this.Green}, blue: {this.Blue}";
    }

    public struct Colors
    {
        public static Rgb Black => new Rgb(0x000000);
        public static Rgb MediumGrey => new Rgb(0x7D7D7D);
        public static Rgb LightGrey => new Rgb(0xCDCDCD);
        public static Rgb White => new Rgb(0xFFFFFF);

        public struct JetBrains
        {
            public static Rgb Amber => new Rgb(0xF9A857);
            public static Rgb Tangerine => new Rgb(0xEC7B75);
            public static Rgb Siena => new Rgb(0xFB5502);
            public static Rgb Crimson => new Rgb(0xFB2046);
            public static Rgb Carmine => new Rgb(0xE32581);
            public static Rgb Fuchsia => new Rgb(0xD73CEA);
            public static Rgb Lilac => new Rgb(0x9135E0);
            public static Rgb Mauve => new Rgb(0x961F8C);
            public static Rgb Purple => new Rgb(0x5E2495);
            public static Rgb Blue => new Rgb(0x5848F4);
            public static Rgb SkyBlue => new Rgb(0x05C1FD);
            public static Rgb Green => new Rgb(0x18D68C);
            public static Rgb LemonYellow => new Rgb(0xFCF84A);
        }
    }

    public class LocalizedText
    {
        public string Text;
        
        LocalizedText(string text)
        {
            this.Text = text;
        }
    }
    
    public enum YachtTextColor
    {
        Light,
        Dark
    }
    
    public enum ScaleformType
    {
        Generic,
        Hud
    }
}