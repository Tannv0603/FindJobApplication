namespace WebApp.Models.ViewModel
{
    public class RatingModel
    {        
        public string Comment { get; set; }
        public bool IsOne { get; set; }
        public bool IsTwo { get; set; }
        public bool IsThree { get; set; }

        public bool IsFour { get; set; }
        public bool IsFive { get; set; }
        public RatingModel(string cmt, bool isOne, bool isTwo,bool isThree, bool isFour, bool isFive)
        {
            Comment = cmt;
            IsOne = isOne;
            IsTwo = isTwo;
            IsThree = isThree;
            IsFour = isFour;
            IsFive = isFive;
        }
        public RatingModel()
        {

        }
    }
}
