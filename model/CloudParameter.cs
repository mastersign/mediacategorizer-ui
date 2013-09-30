using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class CloudParameter : ModelBase
    {
        private const int DEF_WIDTH = 640;
        private const int DEF_HEIGHT = 480;
        private const CloudPrecision DEF_PRECISION = CloudPrecision.Medium;
        private const float DEF_ORDER_PRIORITY = 0.6f;
        private const string DEF_FONT_FAMILY = "Arial";
        private const bool DEF_FONT_BOLD = true;
        private const bool DEF_FONT_ITALIC = false;
        private const float DEF_MIN_FONT_SIZE = 13f;
        private const float DEF_MAX_FONT_SIZE = 80.0f;
        private static readonly ColorRGB DEF_COLOR = new ColorRGB(0.0f, 0.3f, 0.8f);
        private static readonly ColorRGBA DEF_BACKGROUND_COLOR = new ColorRGBA(0.0f, 0.0f, 0.0f, 0.0f);

        private int width;
        private int height;
        private CloudPrecision precision;
        private float orderPriority;
        private string fontFamily;
        private bool fontBold;
        private bool fontItalic;
        private float minFontSize;
        private float maxFontSize;
        private ColorRGB color;
        private ColorRGBA backgroundColor;

        public CloudParameter()
        {
            width = DEF_WIDTH;
            height = DEF_HEIGHT;
            precision = DEF_PRECISION;
            orderPriority = DEF_ORDER_PRIORITY;
            fontFamily = DEF_FONT_FAMILY;
            fontBold = DEF_FONT_BOLD;
            fontItalic = DEF_FONT_ITALIC;
            minFontSize = DEF_MIN_FONT_SIZE;
            maxFontSize = DEF_MAX_FONT_SIZE;
            Color = (ColorRGB) DEF_COLOR.Clone();
            BackgroundColor = (ColorRGBA) DEF_BACKGROUND_COLOR.Clone();
        }

        [DefaultValue(DEF_WIDTH)]
        public int Width
        {
            get { return width; }
            set
            {
                if (value == width) return;
                width = value; 
                OnPropertyChanged("Width");
            }
        }

        [DefaultValue(DEF_HEIGHT)]
        public int Height
        {
            get { return height; }
            set
            {
                if (value == height) return;
                height = value; 
                OnPropertyChanged("Height");
            }
        }

        [DefaultValue(DEF_PRECISION)]
        public CloudPrecision Precision
        {
            get { return precision; }
            set
            {
                if (value == precision) return;
                precision = value; 
                OnPropertyChanged("CloudPrecision");
            }
        }

        [DefaultValue(DEF_ORDER_PRIORITY)]
        public float OrderPriority
        {
            get { return orderPriority; }
            set
            {
                if (Math.Abs(value - orderPriority) < float.Epsilon) return;
                orderPriority = value;
                OnPropertyChanged("OrderPriority");
            }
        }

        [DefaultValue(DEF_FONT_FAMILY)]
        public string FontFamily
        {
            get { return fontFamily; }
            set
            {
                if (value == fontFamily) return;
                fontFamily = value; 
                OnPropertyChanged("FontFamily");
            }
        }

        [DefaultValue(DEF_FONT_BOLD)]
        public bool FontBold
        {
            get { return fontBold; }
            set
            {
                if (value == fontBold) return;
                fontBold = value; 
                OnPropertyChanged("FontBold");
            }
        }

        [DefaultValue(DEF_FONT_ITALIC)]
        public bool FontItalic
        {
            get { return fontItalic; }
            set
            {
                if (value == fontItalic) return;
                fontItalic = value; 
                OnPropertyChanged("FontItalic");
            }
        }

        [DefaultValue(DEF_MIN_FONT_SIZE)]
        public float MinFontSize
        {
            get { return minFontSize; }
            set
            {
                if (Math.Abs(value - minFontSize) < float.Epsilon) return;
                minFontSize = value;
                OnPropertyChanged("MinFontSize");
            }
        }

        [DefaultValue(DEF_MAX_FONT_SIZE)]
        public float MaxFontSize
        {
            get { return maxFontSize; }
            set
            {
                if (Math.Abs(value - maxFontSize) < float.Epsilon) return;
                maxFontSize = value; 
                OnPropertyChanged("MaxFontSize");
            }
        }

        public ColorRGB Color
        {
            get { return color; }
            set
            {
                if (value == color) return;
                if (color != null)
                {
                    color.PropertyChanged -= ChildPropertyChangedHandler;
                }
                color = value;
                if (color != null)
                {
                    color.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("Color");
            }
        }

        public ColorRGBA BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (value == backgroundColor) return;
                if (backgroundColor != null)
                {
                    backgroundColor.PropertyChanged -= ChildPropertyChangedHandler;
                }
                backgroundColor = value;
                if (backgroundColor != null)
                {
                    backgroundColor.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("BackgroundColor");
            }
        }
    }
}
