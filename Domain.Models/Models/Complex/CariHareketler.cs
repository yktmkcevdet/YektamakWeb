namespace Models.Complex
{
    internal class CariHareketler
    {
        public DateTime FaturaTarihi{ get; set; }
        public DateTime VadeTarihi { get; set; }
        public string FisDurumu { get; set; }
        public string Aciklama { get; set; }
        public float BorcTutari { get; set; }
        public float AlacakTutari { get; set;}
    }
}
