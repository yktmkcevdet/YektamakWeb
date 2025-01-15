namespace Models
{
    /// <summary>
    /// Satış tahsilat planı için ödeme tanımı
    /// </summary>
    public class PlanOdeme
    {
        /// <summary>
        /// PlanOdeme tablosu indeksi
        /// </summary>
        public int planOdemeId;
        /// <summary>
        /// 0-1 arası değer alır yüzde oran ifade eder
        /// </summary>
        public float odemeOrani;//0-1 arası değer alacak. Arayüzde formatlanacak
        public OdemeSekli odemeSekli;
        /// <summary>
        /// Ödeme vadesi projenin hangi safhasından sonra sayılacak (sipariş onay, proje onay, ön kabul, fatura kesimi vb.)
        /// </summary>
        public int projeSafhaId;
        /// <summary>
        /// Kaç gün vadeli
        /// </summary>
        public int vade;
        /// <summary>
        /// Bu ödeme kdv ödemesi midir yoksa ana para ödemesi midir
        /// </summary>
        public bool KDVMi;

        //Aşağıdakiler planlama aşamasında değil ödeme gerçekleştiğinde etkilenecek alanlar
        public bool tahsilatGerceklestiMi;
        public DateTime gerceklesmeTarihi;
        public float odenenMiktar;
        public float kalanMiktar;
        public int tahsilatPlaniId;
    }
}
