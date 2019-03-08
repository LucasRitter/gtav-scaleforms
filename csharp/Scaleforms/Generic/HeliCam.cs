namespace LucasRitter.Scaleforms.Generic
{
    // Todo: HeliCam Audio + Logo
    public class HeliCam : Scaleform
    {
        public HeliCam(bool instanced = false) : base("HELI_CAM", instanced)
        {
        }

        #region Properties

        #region Private

        private float _heading = 0.0f;
        private float _fov = 0.0f;
        private float _alt = 0.0f;
        private bool _audioSmallLine = false;
        private bool _audioMediumLine = false;
        private bool _audioLargeLine = false;

        #endregion

        /// <summary>
        /// Gets or sets the heading of the heli-cam in degrees (0 - 359).
        /// </summary>
        public float Heading
        {
            get => _heading;
            set
            {
                _heading = value;
                this.ApplyHeading();
            }
        }

        /// <summary>
        /// Gets or sets the field of view of the heli-cam.(0.0 - 1.0).
        /// </summary>
        public float FieldOfView
        {
            get => _fov;
            set
            {
                _fov = value;
                this.ApplyFov();
            }
        }

        /// <summary>
        /// Gets or sets the altitude of the heli-cam.(0.0 - 400.0).
        /// </summary>
        public float Altitude
        {
            get => _alt;
            set
            {
                _alt = value;
                this.ApplyAltitude();
            }
        }

        #endregion

        #region Methods

        #region Private Mutators

        private void ApplyHeading()
        {
            this.CallFunction("SET_CAM_HEADING", _heading);
        }

        private void ApplyFov()
        {
            this.CallFunction("SET_CAM_FOV", _fov);
        }

        private void ApplyAltitude()
        {
            this.CallFunction("SET_CAM_ALT", _alt);
        }

        #endregion

        #endregion
    }
}