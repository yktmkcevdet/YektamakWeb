namespace Models
{
    public class Tutar:IEntity
    {
        public float tutar;
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) _dovizCinsi = new DovizCinsi(); return _dovizCinsi; } set { _dovizCinsi = value; } }
    }

    public class DovizCinsi:IEntity
    {
        public int id;
        public string sembol;
    }
}
