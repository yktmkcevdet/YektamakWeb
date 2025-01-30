namespace Models
{
    public class Ekran:IEntity
    {
        public int ekranId;
        private Menu _menu;
        public Menu menu
        {
            get
            {
                if (_menu == null)
                    _menu = new Menu();
                return _menu;
            }
            set
            {
                _menu = value;
            }
        }
        public int altMenuId;
        public string ekranAdi;
        public string formAdi;
    }
    public class Menu:IEntity
    {
        public int Id;
        public string ad;
        public string formAdi;
        public string icon;
    }
    public class Yetki:IEntity
    {
        public int yetkiId;
        public int rolId;
		private Ekran _ekran;
		public Ekran ekran
		{
			get
			{
				if (_ekran == null)
					_ekran = new Ekran();
				return _ekran;
			}
			set
			{
				_ekran = value;
			}
		}
		private Menu _menu;
        public Menu menu 
        { 
            get 
            { 
                if(_menu==null) 
                    _menu = new Menu(); 
                return _menu; 
            }
            set 
            {
                _menu = value; 
            }
        }
        
    }
}
