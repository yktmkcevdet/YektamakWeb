namespace Models
{
    public class Kullanici
    {
        public int Id;
        public string ad;
        public string sifre;
        public string salt;
        private Personel _personel;
        public Personel personel { get { if (_personel == null) _personel = new Personel(); return _personel; } set { _personel = value; } }
        public int rolId;
        public bool isSifreDegisti;
    }
    public enum Rol
    {
        admin=1,
        satış=2,
        satınalma=3,
        muhasebe=4,
        ProjeTasarımMühendisi=5,
        ProjeYöneticisi=6,
        ProjeMüdürü=7
    }
}
