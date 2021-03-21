namespace TemplateMvc01.Models
{
    /// <summary>
    /// Error View Model. Scaffolded
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request ID
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Probably not how I would have done it
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
