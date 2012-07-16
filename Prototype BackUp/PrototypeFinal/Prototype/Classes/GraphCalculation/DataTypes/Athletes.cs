using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZedGraph;

namespace Attempt1MathCalculation
{
    /// <summary>
    /// Stores Athlete and Data associated to them
    /// </summary>
    class Athletes
    {
        protected string AthleteName;
        protected string Status;
        protected List<fPoint> Data;
        protected PointPairList list;

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
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="athleteName">Name of the athlete</param>
        /// <param name="status">Placing the athlete got "Medal":"Final":"Other"</param>
        /// <param name="data">List of Points of the athletes Dates and Performances</param>
        public Athletes(string athleteName, string status, List<fPoint> data)
        {
            CreateTrendline ct = new CreateTrendline(data);
            AthleteName = athleteName;
            Status = status;
            Data = data;
            list = ct.getTrendList();
        }
        public Athletes()
        {
            AthleteName = "default";
            Status = "default";
        }
    }
}
