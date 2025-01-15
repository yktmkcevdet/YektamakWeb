namespace Models
{
    public class SatisSiparisTeklifTalep:IEntity
    {
        public int teklifTalepId;
        public DateTime teklifTalepTarihi;
        public Personel satisSorumlusu;
        public Firma musteri;
        public string teklifKonusu;
        public Marka marka;
        public MarkaAltGrup altGrup;
        public int referansKaynakId;
        public Personel maliyetSorumlusu;
        public bool isMaliyetOk;
        public bool isOnay;
    }
}
