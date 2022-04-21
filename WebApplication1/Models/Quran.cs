using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace WebApplication1.Models
{
    public class Quran
    {
        public List<QuranModel> QuranModelData { get; set; }
    }

    public class QuranModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("nomor")]
        public string Nomor { get; set; }

        [JsonProperty("nama")]
        public string Nama { get; set; }

        [JsonProperty("nama_latin")]
        public string NamaLatin { get; set; }

        [JsonProperty("jumlah_ayat")]
        public string JumlahAyat { get; set; }

        [JsonProperty("tempat_turun")]
        public string TempatTurun { get; set; }

        [JsonProperty("arti")]
        public string Arti { get; set; }

        [JsonProperty("deskripsi")]
        public string Deskripsi { get; set; }

        [JsonProperty("audio")]
        public string Audio { get; set; }

        [JsonProperty("ayat")]
        public List<QuranModelAyat> Ayat { get; set; }

        [JsonProperty("tafsir")]
        public List<QuranModelTafsir> Tafsir { get; set; }
    }

    public class QuranModelAyat
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("surah")]
        public string Surah { get; set; }

        [JsonProperty("nomor")]
        public string Nomor { get; set; }

        [JsonProperty("ar")]
        public string BahasaArab { get; set; }

        [JsonProperty("tr")]
        public string Terjemahan { get; set; }

        [JsonProperty("idn")]
        public string Artinya { get; set; }
    }

    public class QuranModelTafsir
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("surah")]
        public string Surah { get; set; }

        [JsonProperty("ayat")]
        public string Ayat { get; set; }

        [JsonProperty("tafsir")]
        public string Tafsir { get; set; }
    }
}