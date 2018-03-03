namespace RobotTest
{
    class SearchResult
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return "Titulo: " + Title + " \n" 
                    + "\r\nUrl: " + Url + " \n"
                    + "\r\nDescription: " + Description + "\r\n\r\n";
        }
    }
}
