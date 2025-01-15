namespace Models
{
    public class CariKart:IEntity
    {
        public int cariKartId;
        public string cariAdi;
        private Cari _cari;
        public Cari cari { get { if (_cari == null) { _cari = new(); } return _cari; } set { _cari = value; } }
        private Tutar _guncelCari;
        public Tutar guncelCari { get { if (_guncelCari == null) { _guncelCari = new(); } return _guncelCari; } set { _guncelCari = value; } }
    }
    public enum CariTuru
    {
       FIRMA= 1,
       PERSONEL=2
    }

    [Serializable]
    public class Cari:IEntity
    {
        public CariTuru cariTuru { get; set; }
        /// <summary>
        /// Cari türü Personelse PersonelId, Firmaysa FirmaId
        /// </summary>
        public int Id;
    }
    
}
