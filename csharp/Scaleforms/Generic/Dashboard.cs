using System;

namespace LucasRitter.Scaleforms.Generic
{
    // Todo: Dashboard (Lights, Dials, Background and Types)
    public class Dashboard : Scaleform
    {
        public Dashboard(bool instanced = false) : base("DASHBOARD", instanced)
        {
        }

        #region Properties

        #region Private

        private string _radioArtist = "";
        private string _radioSong = "";
        private string _radioStation = "";
        private string _radioTuning = "";

        #endregion

        /// <summary>
        /// Gets or sets the current artist on the radio.
        /// Warning: The getter relies on caching, there's no way to get the live value for now.
        /// </summary>
        public string RadioArtist
        {
            get => _radioArtist;
            set
            {
                _radioArtist = value;
                this.ApplyRadio();
            }
        }

        /// <summary>
        /// Gets or sets the current song on the radio.
        /// Warning: The getter relies on caching, there's no way to get the live value for now.
        /// </summary>
        public string RadioSong
        {
            get => _radioSong;
            set
            {
                _radioSong = value;
                this.ApplyRadio();
            }
        }

        /// <summary>
        /// Gets or sets the current radio station name.
        /// Warning: The getter relies on caching, there's no way to get the live value for now.
        /// </summary>
        public string RadioStation
        {
            get => _radioStation;
            set
            {
                _radioStation = value;
                this.ApplyRadio();
            }
        }

        /// <summary>
        /// Gets or sets the current radio tuning.
        /// Warning: The getter relies on caching, there's no way to get the live value for now.
        /// </summary>
        public string RadioTuning
        {
            get => _radioTuning;
            set
            {
                _radioTuning = value;
                this.ApplyRadio();
            }
        }

        // Todo: Dashboard::Type::get()?
        /// <summary>
        /// Sets the current dashboard type.
        /// </summary>
        public DashboardTypes Type
        {
            set => this.CallFunction("SET_VEHICLE_TYPE", (int) value);
        }

        #endregion

        #region Methods

        #region Private Mutators

        private void ApplyRadio()
        {
            this.CallFunction("SET_RADIO", _radioTuning, _radioStation, _radioArtist, _radioSong);
        }

        #endregion

        /// <summary>
        /// Sets the lights on the dashboard.
        /// </summary>
        /// <param name="indicatorLeft"></param>
        /// <param name="indicatorRight"></param>
        /// <param name="handbrakeLight"></param>
        /// <param name="engineLight"></param>
        /// <param name="ABSLight"></param>
        /// <param name="petrolLight"></param>
        /// <param name="oilLight"></param>
        /// <param name="headlights"></param>
        /// <param name="fullBeam"></param>
        /// <param name="batteryLight"></param>
        /// <param name="shiftLight1"></param>
        /// <param name="shiftLight2"></param>
        /// <param name="shiftLight3"></param>
        /// <param name="shiftLight4"></param>
        /// <param name="shiftLight5"></param>
        public void SetLights(
            bool indicatorLeft = false,
            bool indicatorRight = false,
            bool handbrakeLight = false,
            bool engineLight = false,
            bool absLight = false,
            bool petrolLight = false,
            bool oilLight = false,
            bool headlights = false,
            bool fullBeam = false,
            bool batteryLight = false,
            bool shiftLight1 = false,
            bool shiftLight2 = false,
            bool shiftLight3 = false,
            bool shiftLight4 = false,
            bool shiftLight5 = false)
        {
            this.CallFunction("SET_DASHBOARD_LIGHTS", indicatorLeft, indicatorRight,
                handbrakeLight, engineLight, absLight, petrolLight, oilLight, headlights, fullBeam,
                batteryLight, shiftLight1, shiftLight2, shiftLight3, shiftLight4, shiftLight5);
        }

        /// <summary>
        /// Sets the dials on the dashboard.
        /// </summary>
        /// <param name="rpm"></param>
        /// <param name="speed"></param>
        /// <param name="fuel"></param>
        /// <param name="temperature"></param>
        /// <param name="boost"></param>
        /// <param name="oilTemperature"></param>
        /// <param name="oilPressure"></param>
        /// <param name="waterTemp"></param>
        /// <param name="currentGear"></param>
        public void SetDials(
            float rpm = 0f,
            float speed = 0f,
            float fuel = 0f,
            float temperature = 0f,
            float boost = 0f,
            float oilTemperature = 0f,
            float oilPressure = 0f,
            float waterTemp = 0f,
            int currentGear = 1)
        {
            this.CallFunction("SET_DASHBOARD_DIALS", rpm, speed, fuel,
                temperature, boost, oilTemperature, oilPressure, waterTemp, currentGear);
        }

        #endregion


        public enum DashboardTypes
        {
            Banshee,
            Bobcat,
            Cavalcade,
            Comet,
            Dukes,
            Faction,
            Feltzer,
            Feroci,
            Futo,
            GenericTaxi,
            Maverick,
            Peyote,
            Ruiner,
            Speedo,
            Sultan,
            SuperGT,
            Tailgater,
            Truck,
            TruckDigital,
            Infernus,
            ZType,
            Lazer,
            SportBike,
            Default = -1
        }
    }
}