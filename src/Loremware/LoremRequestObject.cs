using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Loremware
{
    public class LoremRequestObject
    {
        private readonly HttpRequest _request;

        public LoremRequestObject(HttpRequest request)
        {
            _request = request;
        }

        public bool IsAjaxRequest
        {
            get
            {
                var ajaxHeader = _request.Headers.Keys.FirstOrDefault(h => h == AjaxRequestHeaderKey);
                return ajaxHeader != null && ajaxHeader == AjaxRequestHeaderValue;
            }
        }

        public LoremContentType ContentType
        {
            get
            {
                if (_request.Path.ToString().Contains(TextMarker) ||
                    _request.QueryString.ToString().Contains(TextMarker))
                    return LoremContentType.Text;
                return LoremContentType.None;
            }
        }

        public int Paragraphs
        {
            get
            {
                return _request.Query.Keys.Contains("para") ? int.Parse(_request.Query["para"]) 
                                                            : DefaultParagraphs;
            }
        }

        public int MaxSentences
        {
            get
            {
                return _request.Query.Keys.Contains("sent") ? int.Parse(_request.Query["sent"])
                                                            : DefaultSentences;
            }
        }

        private const string TextMarker = "tlw";
        private const string AjaxRequestHeaderKey = "X-Requested-With";
        private const string AjaxRequestHeaderValue = "XMLHttpRequest";
        private const int DefaultParagraphs = 3;
        private const int DefaultSentences = 10;
    }

    public enum LoremContentType
    {
        Text,
        Image,
        TextImage,
        None
    }
}
