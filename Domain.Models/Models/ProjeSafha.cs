namespace Models
{
    [System.Serializable]
    public class ProjeSafha
    {
        /// <summary>
        /// ProjeSafha tablosu indeksi
        /// </summary>
        public int projeSafhaId;
        /// <summary>
        /// Proje tablosu indeksi
        /// </summary>
        public int projeId;
        public string projeSafhaAdi;
        public DateTime hedefTarih;
        public DateTime gerceklesmeTarihi;
        public bool SafhaGerceklestiMi;
        public bool isSatisSafha;
        public bool isProjeSafha;
    }
}
