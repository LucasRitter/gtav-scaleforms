namespace LucasRitter.Scaleforms.Generic
{
    public class YachtNameStern : Scaleform
    {
        /// <summary>
        /// Yacht Name Stern.
        /// </summary>
        public YachtNameStern(bool instanced = false) : base("YACHT_NAME_STERN", instanced) {}

        #region Properties
        #region Private
        private string _name = "";
        private string _country = "";
        private YachtTextColor _textColor = YachtTextColor.Dark;
        #endregion
        /// <summary>
        /// Gets or sets the yacht's name.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                ApplyYachtName();
            }
        }
            
        /// <summary>
        /// Gets or sets the yacht's country.
        /// </summary>
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                ApplyYachtName();
            }
        }

        /// <summary>
        /// Gets or sets the yacht's text color.
        /// </summary>
        public YachtTextColor TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                ApplyYachtName();
            }
        }
            
        #endregion
        #region Methods
        #region Private Changers
        /// <summary>
        /// Sets the yacht's name.
        /// </summary>
        private void ApplyYachtName() =>
            this.CallFunction("SET_YACHT_NAME", _name, _textColor == YachtTextColor.Light, _country);
        #endregion
        #endregion
    }
}