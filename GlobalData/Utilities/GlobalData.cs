using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Models;
using Requests;
using Microsoft.Extensions.Configuration;

namespace Utilities

{
    public class GlobalData
    {
        public static List<Sektor> sektorList;
        public static List<Firma> bankaList;
        public static List<DovizCinsi> dovizList;
        public static List<string> ibanErrorList;
        public static List<Marka> markaList;
        public static List<MarkaAltGrup> markaAltGrupList;
        public static List<Firma> firmaUnvanList;
        public static List<KDV> kdvList;
        public static List<Personel> personelList;
        public static List<BankaHesabi> bankaHesabiList;
        public static List<CariKart> cariKartList;
        public static List<Kullanici> kullaniciList;
        public static List<OdemeTanimi> odemeTanimiList;
        public static List<GiderTuru> giderTuruList;
        
        public static List<Menu> menuList;
        public static List<Yetki> yetkiList;
        public static List<Tevkifat> tevkifatList;
        public static List<StokKart> stokKartList;
        public static List<Malzeme> malzemeList;
        public static List<Proje> tumProjeKodList;
        

        public async Task SetGlobals()
        {
            DataSet dataSetGlobalData = JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));


            #region sektorList

            GlobalData.sektorList = new List<Sektor>();
            for (int i = 0; i < dataSetGlobalData.Tables[1].Rows.Count; i++)
            {
                Sektor sektor = new();
                sektor.sektorId = int.Parse(dataSetGlobalData.Tables[1].Rows[i]["Id"].ToString());
                sektor.sektorAd = dataSetGlobalData.Tables[1].Rows[i]["Ad"].ToString();
                GlobalData.sektorList.Add(sektor);
            }

            #endregion sektorList

            #region bankaList
            GlobalData.bankaList = new List<Firma>();
            for (int i = 0; i < dataSetGlobalData.Tables[2].Rows.Count; i++)
            {
                Firma banka = new();

                banka.id = int.Parse(dataSetGlobalData.Tables[2].Rows[i]["FirmaId"].ToString());
                banka.unvan = dataSetGlobalData.Tables[2].Rows[i]["Unvan"].ToString();

                banka.vergiDairesi = dataSetGlobalData.Tables[2].Rows[i]["VergiDairesi"].ToString();
                banka.adres = new Adres();
                banka.adres.sehir = dataSetGlobalData.Tables[2].Rows[i]["Sehir"].ToString();




                GlobalData.bankaList.Add(banka);
            }
            #endregion bankaList

            #region bankaHesabiList
            bankaHesabiList = new List<BankaHesabi>();

            foreach (DataRow dr in dataSetGlobalData.Tables[3].Rows)
            {
                BankaHesabi bankaHesabi = new();
                bankaHesabi.hesapId = int.Parse(dr["hesapId"].ToString());
                bankaHesabi.hesapAdi = dr["hesapAdi"].ToString();
                bankaHesabi.banka.id = int.Parse(dr["banka_id"].ToString());
                bankaHesabi.dovizCinsi.id = int.Parse(dr["dovizCinsi_id"].ToString());
                bankaHesabiList.Add(bankaHesabi);
            }

            #endregion bankaHesabiList

            #region dovizList
            GlobalData.dovizList = new List<DovizCinsi>();
            //Console.WriteLine("dovizList ; ");
            for (int i = 0; i < dataSetGlobalData.Tables[4].Rows.Count; i++)
            {
                DovizCinsi doviz = new();
                doviz.id = int.Parse(dataSetGlobalData.Tables[4].Rows[i]["Id"].ToString());
                doviz.sembol = dataSetGlobalData.Tables[4].Rows[i]["ad"].ToString();
                dovizList.Add(doviz);
                //Console.WriteLine($"dovizId : {doviz.id.ToString()}, dovizSembol : {doviz.sembol}");
            }
            #endregion dovizList

            #region ibanErrorList
            ibanErrorList = new List<string>();
            ibanErrorList.Add("Good");//0
            ibanErrorList.Add("Non-numeric Character");//1
            ibanErrorList.Add("Character Count Exceed or Insufficient");//2
            #endregion ibanErrorList

            #region markaList
            GlobalData.markaList = new List<Marka>();
            GlobalData.markaAltGrupList = new List<MarkaAltGrup>();
            for (int i = 0; i < dataSetGlobalData.Tables[5].Rows.Count; i++)
            {
                Marka marka = new();
                marka.markaId = int.Parse(dataSetGlobalData.Tables[5].Rows[i]["Id"].ToString());
                marka.markaAd = dataSetGlobalData.Tables[5].Rows[i]["ad"].ToString();
                marka.prefix = dataSetGlobalData.Tables[5].Rows[i]["kod"].ToString();
                GlobalData.markaList.Add(marka);
            }
            for (int i = 0; i < dataSetGlobalData.Tables[6].Rows.Count; i++)
            {
                MarkaAltGrup altGrup = new();
                altGrup.altGrupId = int.Parse(dataSetGlobalData.Tables[6].Rows[i]["Id"].ToString());
                altGrup.altGrupAd = dataSetGlobalData.Tables[6].Rows[i]["ad"].ToString();
                altGrup.markaId = int.Parse(dataSetGlobalData.Tables[6].Rows[i]["MarkaId"].ToString());
                GlobalData.markaAltGrupList.Add(altGrup);
            }
            #endregion markaList

            #region kdvList
            //GlobalData.kdvList = new List<KDV>();
            //for (int i = 0; i < dataSetGlobalData.Tables[7].Rows.Count; i++)
            //{
            //    KDV kdv = new();
            //    kdv.kdvId = int.Parse(dataSetGlobalData.Tables[7].Rows[i]["KDVId"].ToString());
            //    kdv.kdvOrani = int.Parse(dataSetGlobalData.Tables[7].Rows[i]["KDVOrani"].ToString());
            //    GlobalData.kdvList.Add(kdv);
            //}
            #endregion kdvList

            #region personelList
            personelList = new List<Personel>();
            foreach (DataRow dr in dataSetGlobalData.Tables[7].Rows)
            {
                Personel personel = new();
                personel.personelId = int.Parse(dr["Id"].ToString());
                personel.ad = dr["ad"].ToString();
                personel.soyad = dr["soyad"].ToString();
                personel.telefon = dr["telefon"].ToString();
                personel.mail = dr["mail"].ToString();
                personel.pozisyon = dr["pozisyon"].ToString();
                personelList.Add(personel);
            }
            #endregion personelList

            //#region cariKartList
            //cariKartList = new List<CariKart>();
            //foreach (DataRow dr in dataSetGlobalData.Tables[9].Rows)
            //{
            //    CariKart cariKart = new();
            //    cariKart.cariKartId = int.Parse(dr["cariKartId"].ToString());
            //    cariKart.cariAdi = dr["cariAdi"].ToString();
            //    cariKart.cari = new Cari();
            //    cariKart.cari.Id = int.Parse(dr["cari_Id"].ToString());
            //    cariKart.guncelCari = new Tutar();
            //    cariKart.guncelCari.dovizCinsi.id = int.Parse(dr["guncelCari_dovizCinsi_id"].ToString());
            //    cariKartList.Add(cariKart);
            //}
            //#endregion cariKartList

            #region kullanicilList
            kullaniciList = new List<Kullanici>();
            foreach (DataRow dr in dataSetGlobalData.Tables[8].Rows)
            {
                Kullanici kullanici1 = new();
                kullanici1.Id = int.Parse(dr["Id"].ToString());
                kullanici1.ad = dr["ad"].ToString();
                kullanici1.rolId = int.Parse(dr["rolId"].ToString());
                kullaniciList.Add(kullanici1);
            }
            #endregion kullaniciList

            //#region odemeTanimiList
            //odemeTanimiList = new List<OdemeTanimi>();
            //foreach (DataRow dr in dataSetGlobalData.Tables[14].Rows)
            //{
            //    OdemeTanimi odemeTanimi = new();
            //    odemeTanimi.odemeTanimiId = int.Parse(dr["odemeTanimiId"].ToString());
            //    odemeTanimi.odemeTanimi = dr["odemeTanimi"].ToString();
            //    odemeTanimiList.Add(odemeTanimi);
            //}
            //#endregion odemeTanimiList

            //#region giderTuruList
            //giderTuruList = new List<GiderTuru>();
            //foreach (DataRow dr in dataSetGlobalData.Tables[16].Rows)
            //{
            //    GiderTuru giderTuru = new();
            //    giderTuru.giderTurId = int.Parse(dr["giderTurId"].ToString());
            //    giderTuru.giderTuru = dr["giderTuru"].ToString();
            //    giderTuruList.Add(giderTuru);
            //}
            //#endregion giderTuruList

            //#region tevkifatList
            //tevkifatList = new List<Tevkifat>();
            //foreach (DataRow dr in dataSetGlobalData.Tables[20].Rows)
            //{
            //    Tevkifat tevkifat = new();
            //    tevkifat.tevkifatId = int.Parse(dr["TevkifatId"].ToString());
            //    tevkifat.tevkifatOrani = float.Parse(dr["TevkifatOrani"].ToString());
            //    tevkifat.tevkifatAciklama = dr["TevkifatAciklama"].ToString();
            //    tevkifatList.Add(tevkifat);
            //}
            //#endregion tevkifatList
            #region anaMenuList
           
            #endregion anaMenuList

            #region menuList
            menuList = new List<Menu>();
            foreach (DataRow dr in dataSetGlobalData.Tables[11].Rows)
            {
                Menu menu = new();
                menu.menuId = int.Parse(dr["menuId"].ToString());
                menu.menuAdi = dr["menuAdi"].ToString();
                menu.icon = dr["icon"].ToString();
                menuList.Add(menu);
            }
            #endregion menuList

            #region yetkiList
            
            #endregion yetkiList

            #region stokKartList
            stokKartList = new List<StokKart>();
            foreach (DataRow dr in dataSetGlobalData.Tables[12].Rows)
            {
                StokKart stokKart = new();
                stokKart.Id = int.Parse(dr["StokKartId"].ToString());
                stokKart.kod = dr["stokKartKodu"].ToString();
                stokKart.ad = dr["stokKartAdi"].ToString();
                //stokKart.malzeme.malzemeId = int.Parse(dr["malzemeGrupId"].ToString());
                stokKart.boyut = dr["boyut"].ToString();
                stokKartList.Add(stokKart);
            }
            #endregion stokKartList

            //#region malzemeList
            //malzemeList = new List<Malzeme>();
            //foreach (DataRow dr in dataSetGlobalData.Tables[22].Rows)
            //{
            //    Malzeme malzeme = new Malzeme();
            //    malzeme.malzemeId = Int32.Parse(dr["malzemeId"].ToString());
            //    malzeme.malzemeKodu = dr["malzemeKodu"].ToString();
            //    malzeme.malzemeAdi = dr["malzemeAdi"].ToString();
            //}
            //#endregion malzemeList

            #region tumProjeKodList
            tumProjeKodList = new List<Proje>();
            foreach (DataRow dr in dataSetGlobalData.Tables[13].Rows)
            {
                Proje projeKod = new();
                projeKod.Id = Int32.Parse(dr["projeId"].ToString());
                projeKod.kod = dr["projeKod"].ToString();
                tumProjeKodList.Add(projeKod);
            }
            #endregion tumProjeKodList

            #region firmaUnvanList

            GlobalData.firmaUnvanList = new List<Firma>();
            for (int i = 0; i < dataSetGlobalData.Tables[0].Rows.Count; i++)
            {
                Firma firma = new();
                firma.id = int.Parse(dataSetGlobalData.Tables[0].Rows[i]["Id"].ToString());
                firma.unvan = dataSetGlobalData.Tables[0].Rows[i]["ad"].ToString();
                GlobalData.firmaUnvanList.Add(firma);
            }
            #endregion firmaUnvanList
        }
        
        public static string GetSymbolFromDovizId(int dovizId)
        {
            return GlobalData.dovizList.Find(x => x.id == dovizId).sembol;
        }
        public static Sektor GetSektorFromId(int sektorId)
        {
            if (sektorId<=0)
            {
                return null;
            }
            return sektorList.Find(x=>x.sektorId== sektorId);
        }
        public static string GetSektorNameFromId(int sektorId)
        {
            if (sektorId<=0)
            {
                return string.Empty;
            }
            return sektorList.Find(x => x.sektorId == sektorId).sektorAd;
        }
        public static void HandleException(Action action) 
        {
            try
            {
                action.Invoke();
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }
        public static DataSet HandleException(Func<DataSet> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return null;
            }
        }
        public static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = password + salt;
            var bytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
        /// <summary>
        /// Kullanıcının form için yetkisinin olup olmadığı kontrolünü yapar. Ywtkisi varsa formu activeFormStack listesine ekler.
        /// Yetkisi yoksa formun değişken değerini null yapar ve form açılmaz.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <returns></returns>
        //public static bool Yetki<T>(ref T form) where T : Form
        //{
        //    bool yetki = false;
        //    DataSet dataSet = JsonStringToDataSet(WebMethods.GetKullaniciYetki(kullanici));
        //    if (dataSet.Tables[1].Select("YetkiId is not null and FormAdi='" + form.Name + "'").Count() > 0)
        //    {
        //        yetki = true;
        //        GlobalData.AddNewForm(form);
        //    }
        //    else
        //    {
        //        form = null;
        //        MessageBox.Show("Bu işlem için yetkiniz yok");
        //    }
        //    return yetki;
        //}
        /// <summary>
        /// web isteklerinden dönen json değerlerini dataset nesnesine dönüştürür
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static DataSet JsonStringToDataSet(string result)
        {
            return HandleException(() =>
            {
                DataSet dataSet = new DataSet(); // Default empty DataSet

                if (!result.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
                    string json = Encoding.UTF8.GetString(bytes);
                    dataSet = JsonConvert.DeserializeObject<DataSet>(json);
                }
                else
                {
                    //MessageBox.Show(result);
                    dataSet = null;
                }

                return dataSet;
            });
        }
        public static T GetModelFromDatabase<T>(Func<T,string> func,T model,int rowIndex=0) where T : IEntity, new()
        {
            string result = func(model);
            DataSet dataSet=JsonStringToDataSet(result);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[rowIndex];
                return DataRowToModel<T>(dataRow);
            }
            else
            {
                return model;
            }
            
        }
        public static async Task<T> GetModelFromDatabase<T>(Func<T, Task<string>> func, T model, int rowIndex = 0) where T : IEntity, new()
        {
            string result = await func(model);
            DataSet dataSet = JsonStringToDataSet(result);
            DataRow dataRow = dataSet.Tables[0].Rows[rowIndex];
            return DataRowToModel<T>(dataRow);
        }
        public static T DataRowToModel<T>(DataRow dataRow, string upClassName = "") where T : IEntity, new()
        {
            T entity = new T();
            foreach (FieldInfo fieldInfo in entity.GetType().GetFields())
            {
                if (dataRow.Table.Columns.Contains(upClassName + fieldInfo.Name))
                {
                    object value = null;
                    if (fieldInfo.FieldType == typeof(Byte[]))
                    {
                        value = JsonConvert.DeserializeObject<byte[]>("\"" + dataRow[upClassName + fieldInfo.Name].ToString() + "\"");
                    }
                    else
                    {
                        object data = dataRow[upClassName + fieldInfo.Name];
                        if (data.ToString() == "" && (fieldInfo.FieldType == typeof(int) || fieldInfo.FieldType == typeof(Single) || fieldInfo.FieldType == typeof(float))) //data değeri sayısal değerse
                        {
                            value = Convert.ChangeType(0, fieldInfo.FieldType);
                        }
                        else
                        {

                            if (Nullable.GetUnderlyingType(fieldInfo.FieldType) == typeof(bool))
                            {
                                // FieldType bir Nullable<bool> türü ise
                                if (data is int intValue)
                                {
                                    // Eğer data bir int ise, 1'i true, 0'ı false, diğer değerleri null yapıyoruz.
                                    value = intValue == 1 ? (bool?)true : (intValue == 0 ? (bool?)false : null);
                                }
                                else if (data is bool boolValue)
                                {
                                    // Eğer data bir boolean ise, doğrudan atama yapabiliriz
                                    value = (bool?)boolValue;
                                }
                                else
                                {
                                    // Farklı veri tipi için hata veya başka bir işlem yapılabilir
                                    value = null;
                                }
                            }
                            else
                            {
                                // Eğer FieldType Nullable<bool> değilse, başka türler için işlemler yapılabilir.
                                value = Convert.ChangeType(data, fieldInfo.FieldType);
                            }
                        }
                    }
                    fieldInfo.SetValue(entity, value);
                }
            }
            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                Type type = propertyInfo.PropertyType;
                if (dataRow.Table.Columns.Contains(upClassName + propertyInfo.Name))
                {
                    if (type == typeof(string) || type.IsPrimitive)
                    {
                        object value = null;
                        string data = dataRow[upClassName + propertyInfo.Name].ToString();
                        if (data.ToString() == "" && propertyInfo.PropertyType == typeof(int))
                        {
                            value = Convert.ChangeType(0, propertyInfo.PropertyType);
                        }
                        else
                        {
                            value = Convert.ChangeType(data, propertyInfo.PropertyType);
                        }
                        propertyInfo.SetValue(entity, value);
                    }
                    else
                    {
                        string data = dataRow[upClassName + propertyInfo.Name].ToString();
                        //if (typeof(UserControl).IsAssignableFrom(type))
                        //{
                        //    if (type == typeof(CustomComboListBox))
                        //    {
                        //        MethodInfo method = type.GetMethod("SelectDataRowId");
                        //        if (method != null)
                        //        {
                        //            object[] parameters = new object[] { Convert.ToInt32(dataRow[propertyInfo.Name]) };
                        //            method.Invoke(propertyInfo.GetValue(entity), parameters);
                        //        }
                        //    }
                        //    else if (type == typeof(CustomTextBox) || type == typeof(CustomTextBoxSayisal) || type == typeof(CustomTextBoxTarih))
                        //    {
                        //        if (dataRow.Table.Columns.Contains(propertyInfo.Name))
                        //        {
                        //            type.GetProperty("TextCustom").SetValue(propertyInfo.GetValue(entity), Convert.ToString(dataRow[propertyInfo.Name]));
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    object value = JsonConvert.DeserializeObject(data, type);
                        //    propertyInfo.SetValue(entity, value);
                        //}

                    }
                }


                else if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    MethodInfo method = typeof(GlobalData).GetMethod("DataRowToModel").MakeGenericMethod(type);
                    object value = method.Invoke(null, new object[] { dataRow, upClassName + propertyInfo.Name + "_" });
                    propertyInfo.SetValue(entity, value);
                }
            }
            return entity;
        }

        /// <summary>
        /// Mail gönderme işlemi yapar.
        /// </summary>
        /// <param name="receiverEmailAdress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string receiverEmailAdress, string subject,string body)
        {
            // E-posta gönderenin bilgileri
            string senderEmail = "noreply@yektamak.com.tr";
            string senderPassword = "Yod43257";

            // SmtpClient ve MailMessage oluşturulması
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage(senderEmail, receiverEmailAdress, subject, body);


            // E-postanın gönderilmesi
            smtpClient.Send(mailMessage);
        }
        


    }

    
	
	public enum IbanPrefix
    {
        TR=0
    }
    
    /// <summary>
    /// Dataset satırını model nesnesine dönüştürür
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataRow"></param>
    /// <returns></returns>
    
}
