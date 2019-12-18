using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Dapper
{
    public class TemperatureRecord
    {
        public string ID { get; set; }
        public DateTime 時間 { get; set; }
        public double 第1段溫度顯示值 { get; set; }
        public double 第2段溫度顯示值 { get; set; }
        public double 第3段溫度顯示值 { get; set; }
        public double 第4段溫度顯示值 { get; set; }
        public double 第5段溫度顯示值 { get; set; }
        public double 第6段溫度顯示值 { get; set; }
    }
}
