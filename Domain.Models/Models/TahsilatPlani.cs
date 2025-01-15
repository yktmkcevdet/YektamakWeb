namespace Models
{
    [Serializable]
    public class TahsilatPlani
    {
        /// <summary>
        /// TahsilatPlani tablosu indeksi
        /// </summary>
        public int tahsilatPlaniId;
        /// <summary>
        /// SatisSiparis tablosu indeksi
        /// </summary>
        public int siparisId;
        /// <summary>
        /// Tahsilat planına kdv ödemesi dahil midir?
        /// </summary>
        public bool kdvDahilMi;
        public string aciklamalar;
    }
}
