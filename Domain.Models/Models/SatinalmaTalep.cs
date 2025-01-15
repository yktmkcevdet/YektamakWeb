namespace Models
{
    public class SatinalmaTalepBaslik:IEntity
	{
		public int Id;
		public string satinalmaTalepNo;
		public DateTime talepTarihi;
		public int parcaGrupId;
        private Proje _proje;
		public Proje proje
		{
			get
			{
				if(_proje == null) 
				{ 
					_proje = new Proje();
				}
				return _proje;
			}
			set
			{
				_proje = value;
			}
		}
		public int talepEdenKullaniciId;
		public TalepTip _talepTip;
		public TalepTip talepTip
		{
			get
			{
				if (_talepTip == null)
				{
					_talepTip=new TalepTip();
				}
				return _talepTip;
			}
			set
			{
				_talepTip = value;
			}
		}
		public string aciklama;
		private List<SatinalmaTalepDetay> _satinalmaTalepDetay;
		public List<SatinalmaTalepDetay> satinalmaTalepDetay
		{
			get { if (_satinalmaTalepDetay == null) _satinalmaTalepDetay = new List<SatinalmaTalepDetay>(); return _satinalmaTalepDetay; }
			set { _satinalmaTalepDetay = value; }
		}
	}
	public class SatinalmaTalepDetay : IEntity
	{
		public int id;
		//private SatinalmaTalepBaslik _satinalmaTalepBaslik;
		//public SatinalmaTalepBaslik satinalmaTalepBaslik
		//{
		//	get
		//	{
		//		if (_satinalmaTalepBaslik == null)
		//		{
		//			_satinalmaTalepBaslik=new SatinalmaTalepBaslik();
		//		}
		//		return _satinalmaTalepBaslik;
		//	}
		//	set
		//	{
		//		_satinalmaTalepBaslik = value;
		//	}
		//}
		private StokKart _stokKart;
		public StokKart stokKart{
			get
			{
				if (_stokKart == null)
				{
					_stokKart = new StokKart();
				}
				return _stokKart;
			}
			set
			{
				_stokKart = value;
			}
		}
		public double miktar;
		public string aciklama;
		public DateTime talepTarihi;
	}
	public class TalepTip:IEntity
	{
		public int talepTipId;
		public string talepTipi;
		public string kod;
	}

}
