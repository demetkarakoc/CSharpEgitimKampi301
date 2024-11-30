using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
          // Toplam Lokasyon sayısı

            var locationCount = db.TblLocation.Count();
            lblLocationCount.Text = db.TblLocation.Count().ToString();
            
            //Toplam kapasite 
            lblCapacity.Text = db.TblLocation.Sum(x=>x.Capacity).ToString();

            //Rehber sayısı
            lblGuide.Text = db.TblLocation.Count().ToString();

            //ortalama kapasite
            lblAverageCapacity.Text = db.TblLocation.Average(x => x.Capacity).ToString();

            //ortalama tur fiyatı
            lblAverageLocationPrice.Text = db.TblLocation.Average(x=>x.Price).ToString();

            //eklenen son ülke 
            int lastCountryId = db.TblLocation.Max(x=>x.LocationId);
            lblLastCountry.Text = db.TblLocation.Where(x=>x.LocationId==lastCountryId).Select(y=>y.Country).FirstOrDefault();

            //kapadokya tur kapasitesi
            lblCappadocia.Text =db.TblLocation.Where(x=>x.City=="Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();

            //Türkiye ortalama tur kapasitesi
            lblAverageCapacity.Text = db.TblLocation.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();

            //Roma gezisi tur rehberi ismi
            var romeGuideId = db.TblLocation.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.TblGuide.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName+""+y.GuideSurname).FirstOrDefault().ToString();

            //En yüksek kapasiteli tur
            var maxCapacity = db.TblLocation.Max(x=>x.Capacity);
            lblMaxCapacity.Text=db.TblLocation.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            //En pahalı tur
            var maxPrice = db.TblLocation.Max(x=>x.Price);
            lblMaxPrice.Text = db.TblLocation.Where(x=>x.Price == maxPrice).Select(y =>y.City).FirstOrDefault().ToString();

            //Neriman öztürk tur sayısı
            var guideIdByNameNerimanOzturk = db.TblGuide.Where(x=>x.GuideName=="Neriman" && x.GuideSurname=="Öztürk" ).Select(y=>y.GuideId).FirstOrDefault();
            lblNeriman.Text = db.TblLocation.Where(x=>x.GuideId==guideIdByNameNerimanOzturk).Count().ToString();


        }
    }
}
