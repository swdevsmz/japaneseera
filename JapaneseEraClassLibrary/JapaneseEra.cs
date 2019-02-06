using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace JapaneseEraClassLibrary
{
    /// <summary>
    /// 和暦クラスです。
    /// </summary>
    public static class JapaneseEra
    {

        [System.Xml.Serialization.XmlElement("EraTable")]
        private static readonly EraTable table;

        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static JapaneseEra()
        {
            using (FileStream fs = new System.IO.FileStream(Directory.GetCurrentDirectory() + @"\\EraTable.xml", System.IO.FileMode.Open))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EraTable));
                    table = (EraTable)serializer.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    throw new IOException("xmlファイルの読込に失敗しました。", ex);
                }
            }
        }

        /// <summary>
        /// 日付に該当するJapaneseEraインスタンスを得る 
        /// </summary>
        /// <param name="theDate"></param>
        /// <returns></returns>
        private static Era GetEra(DateTime theDate)
          => table.eras.FirstOrDefault(era => (era.StartDateTime.Date <= theDate.Date && theDate.Date <= era.EndDateTime.Date));

        /// <summary>
        /// 日付から和暦の年月日を得る
        /// </summary>
        /// <param name="theDate"></param>
        /// <returns></returns>
        public static string GetYMD(DateTime theDate)
        {
            var e = GetEra(theDate);
            return $"{e.Name}{(theDate.Year - e.StartDateTime.Year + 1):00}年{theDate:MM月dd日}";
        }

    }

    [System.Xml.Serialization.XmlRoot("EraTable")]
    public class EraTable
    {
        /// <summary>
        /// 人
        /// </summary>
        [System.Xml.Serialization.XmlElement("Era")]
        public List<Era> eras { get; set; }
    }

    public class Era
    {
        /// <summary>
        /// 元号の開始日 
        /// </summary>
        [System.Xml.Serialization.XmlElement("StartDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// 元号の開始日 
        /// </summary>
        [System.Xml.Serialization.XmlElement("EndDate")]
        public string EndDate { get; set; }

        /// <summary>
        ///  元号の名称 
        /// </summary>
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// ローマ字表記の名称
        /// </summary>
        [System.Xml.Serialization.XmlElement("EnglishName")]
        public string EnglishName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public DateTime StartDateTime
        {
            get{
                return DateTime.Parse(this.StartDate);
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public DateTime EndDateTime
        {
            get
            {
                return String.IsNullOrEmpty(this.EndDate) ? DateTime.MaxValue : DateTime.Parse(this.EndDate);
            }
        }
    }


}
