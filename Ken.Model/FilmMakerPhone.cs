namespace Ken.Models
{
    /// <summary>
    /// 影人图片
    /// </summary>
    public class FilmMakerPhone:EntityBase
    {
        /// <summary>
        /// 影人Id
        /// </summary>
        public int Fid { get; set; }

        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string FileUrl { get; set; }
    }
}
