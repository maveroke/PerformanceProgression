using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZedGraph;

namespace Attempt1MathCalculation
{
    struct Athletes
    {
        private string AthleteName;
        private string Status;
        private string Event;//either track or field
        private List<fPoint> Data;
        private PointPairList List;

        public static Athletes ConstructDefault()
        {
            return new Athletes("default", "default", new List<fPoint>(),"default");
        }
        /// <param name="athleteName">Name of the athlete</param>
        /// <param name="status">Placing the athlete got "Medal":"Final":"Other"</param>
        /// <param name="data">List of Points of the athletes Dates and Performances</param>
        public Athletes(string athleteName, string status, List<fPoint> data,string eventType)
        {
            this.AthleteName = athleteName;
            this.Status = status;
            this.Data = new List<fPoint>();
            this.List = new PointPairList();
            if (eventType.CompareTo("e.g. mm:ss.ss") == 0) { this.Event = "Track"; }
            else { this.Event = "Field"; }
            if (data[0].getX_Age().CompareTo(1111f) != 0)
            {
                CreateTrendline ct = new CreateTrendline(data,this.Event);
                List = ct.getTrendList();
            }
            
            AthleteName = athleteName;
            Status = status;
            Data = data;

        }
        public string getName()
        {
            return AthleteName;
        }
        public string getStatus()
        {
            return Status;
        }
        public List<fPoint> getData()
        {
            return Data;
        }
        public PointPairList getCurveData()
        {
            return List;
        }

     }
}
