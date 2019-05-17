using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class Classification
    {
        public Classification()
        {
            InverseClassificationGroup = new HashSet<Classification>();
            InverseClassificationHeader = new HashSet<Classification>();
        }

        public int ClassificationId { get; set; }
        public int Sequence { get; set; }
        public string DataCode { get; set; }
        public string DataDescription { get; set; }
        public int? ClassificationGroupId { get; set; }
        public int? ClassificationHeaderId { get; set; }
        public string ClassificationSchema { get; set; }
        public int? ClassificationOptionList { get; set; }
        public bool? IsOptionList { get; set; }
        public bool? IsRemoved { get; set; }

        public virtual Classification ClassificationGroup { get; set; }
        public virtual Classification ClassificationHeader { get; set; }
        public virtual ICollection<Classification> InverseClassificationGroup { get; set; }
        public virtual ICollection<Classification> InverseClassificationHeader { get; set; }
    }
}
