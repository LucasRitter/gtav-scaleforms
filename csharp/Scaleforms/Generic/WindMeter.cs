namespace LucasRitter.Scaleforms.Generic
{
    // Todo: Add regions to WindMeter class
    public class WindMeter : Scaleform
    {
        /// <summary>
        /// Wind Meter.
        /// </summary>
        public WindMeter(bool instanced = false) : base("WIND_METER", instanced)
        {
            ApplyArrowColor();
        }

        private int _windDirection = 0;

        /// <summary>
        /// Gets or sets the direction of the wind in degrees.
        /// </summary>
        public int WindDirection
        {
            get => _windDirection;
            set
            {
                _windDirection = value;
                ApplyWindDirection();
            }
        }

        private int _windStrength = 0;

        /// <summary>
        /// Gets or sets the strength of the wind in miles per hour.
        /// </summary>
        public int WindStrength
        {
            get => _windStrength;
            set
            {
                _windStrength = value;
                ApplyWindDirection();
            }
        }

        /// <summary>
        /// Sets the wind direction and strength of the wind meter.
        /// </summary>
        private void ApplyWindDirection() =>
            this.CallFunction("SET_WIND_DIRECTION", this._windDirection, this._windStrength);


        private int _compassRotation = 0;

        /// <summary>
        /// Gets or sets the rotation of the compass.
        /// </summary>
        public int CompassRotation
        {
            get => _compassRotation;
            set
            {
                _compassRotation = value;
                this.ApplyCompassDirection();
            }
        }

        /// <summary>
        /// Sets the direction of the compass.
        /// </summary>
        private void ApplyCompassDirection() =>
            this.CallFunction("SET_COMPASS_DIRECTION", _compassRotation);

        private Rgb _arrowColor = Colors.JetBrains.Green;

        /// <summary>
        /// Gets or sets the foreground color of the wind pointer arrow.
        /// </summary>
        public Rgb ArrowColor
        {
            get => _arrowColor;
            set
            {
                _arrowColor = value;
                ApplyArrowColor();
            }
        }

        private Rgb _arrowBackgroundColor = Colors.White;

        /// <summary>
        /// Gets or sets the background color of the wind pointer arrow.
        /// </summary>
        public Rgb ArrowBackgroundColor
        {
            get => _arrowBackgroundColor;
            set
            {
                _arrowBackgroundColor = value;
                ApplyArrowBackgroundColor();
            }
        }

        /// <summary>
        /// Sets the foreground color of the wind pointer arrow.
        /// </summary>
        private void ApplyArrowColor() =>
            this.CallFunction("TINT_WIND_POINTER", 0,
                _arrowColor.Red, _arrowColor.Green, _arrowColor.Blue);

        /// <summary>
        /// Sets the background color of the wind pointer arrow.
        /// </summary>
        private void ApplyArrowBackgroundColor() =>
            this.CallFunction("TINT_WIND_POINTER", 1,
                _arrowBackgroundColor.Red, _arrowBackgroundColor.Green, _arrowBackgroundColor.Blue);
    }
}