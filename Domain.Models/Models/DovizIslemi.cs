namespace Models
{
    /// <summary>
    /// Bir döviz hesabındaki dövizi bankaya satıp , bir TL hesabına karşılığı olan parayı yatırma işlemi veya tam tersi için kullanılır.
    /// </summary>
    public class DovizIslemi:IEntity
    {
        public int dovizIslemId;
        public DateTime islemTarihi;
        private Tutar _satilanTutar;
        public Tutar satilanTutar { get { if (_satilanTutar==null) { _satilanTutar = new(); } return _satilanTutar; } set { _satilanTutar = value; } }
        private Tutar _alinanTutar;
        public Tutar alinanTutar { get { if (_alinanTutar == null) { _alinanTutar = new(); } return _alinanTutar; } set { _alinanTutar = value; } }
        public IKasa cekilenKasa;
        public IKasa yatirilanKasa;
    }
}
