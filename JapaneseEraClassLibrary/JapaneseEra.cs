using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseEraClassLibrary
{
    /// <summary>
    /// 和暦クラスです。
    /// </summary>
    public class JapaneseEra
    {
        /// <summary>
        /// 元号の開始日 
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        ///  元号の名称 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 元号の頭文字
        /// </summary>
        public string FirstLetter { get; }

        /// <summary>
        /// ローマ字表記の名称
        /// </summary>
        public string EnglishName { get; }

        /// <summary>
        /// ローマ字表記の頭文字
        /// </summary>
        public string EnglishFirstLetter { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="name"></param>
        /// <param name="englishName"></param>
        private JapaneseEra(DateTime startDate, string name, string englishName)
        {
            StartDate = startDate;
            Name = name;
            FirstLetter = Name.Substring(0, 1);
            EnglishName = englishName;
            EnglishFirstLetter = EnglishName.Substring(0, 1);
        }

        /// <summary>
        /// 静的プロパティ：JapaneseEraインスタンスを収めた読み取り専用のリスト 
        /// </summary>
        public static IList<JapaneseEra> Table { get; }
          = new List<JapaneseEra>() // 順序が保証されるコレクションを使う
          {
              // 必ず降順に並べる
              new JapaneseEra(new DateTime(2019,5,1), "新元", "Shingen"),
              new JapaneseEra(new DateTime(1989,1,8), "平成", "Heisei"),
              new JapaneseEra(new DateTime(1926,12,25), "昭和", "Showa"),
              new JapaneseEra(new DateTime(1912,7,30), "大正", "Taisho"),
              new JapaneseEra(new DateTime(1868,1,25), "明治", "Meiji"),
          }
          .AsReadOnly(); // リストの内容を変更できないようにする

        /// <summary>
        /// 日付に該当するJapaneseEraインスタンスを得る 
        /// </summary>
        /// <param name="theDate"></param>
        /// <returns></returns>
        private static JapaneseEra GetEra(DateTime theDate)
          => Table.FirstOrDefault(era => (era.StartDate <= theDate));

        /// <summary>
        /// 日付から和暦の年月日を得る
        /// </summary>
        /// <param name="theDate"></param>
        /// <returns></returns>
        public static string GetEraYMD(DateTime theDate)
        {
            var e = GetEra(theDate);
            return $"{e.Name}{(theDate.Year - e.StartDate.Year + 1):00}年{theDate:MM月dd日}";
        }
    }
}
