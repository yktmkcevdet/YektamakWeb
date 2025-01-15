namespace Models
{
    public class Marka:IEntity
    {
        public int markaId;
        public string markaAd;
        public string prefix;
        private MarkaAltGrup _markaAltGrup;
        public MarkaAltGrup markaAltGrup { get { if (_markaAltGrup == null) { _markaAltGrup = new(); } return _markaAltGrup; } set { _markaAltGrup = value; } }
    }
    public class MarkaAltGrup:IEntity
    {
        public int altGrupId;
        public string altGrupAd;
        public int markaId;
    }
}
