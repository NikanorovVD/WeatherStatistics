using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using WeatherStatistics.Data;

namespace WeatherStatistics.Services
{
    public class ExcelReaderService: IStatisticsReader
    {
        private int start_row_num = 4;
        public ExcelReaderService() { }
        public IEnumerable<WeatherRecord> ReadStatistics(Stream fileStream)
        {
            IWorkbook book;
            List<WeatherRecord> records = new List<WeatherRecord>();
            book = new XSSFWorkbook(fileStream);

            for (int sheet_num = 0; sheet_num < book.NumberOfSheets; sheet_num++)
            {
                ISheet sheet = book.GetSheetAt(sheet_num);

                for (int row_num = start_row_num; row_num < sheet.LastRowNum + 1; row_num++)
                {
                    IRow row = sheet.GetRow(row_num);

                    WeatherRecord record = new()
                    {
                        Date = DateOnly.Parse(row.GetCell(0).StringCellValue),
                        Time = TimeOnly.Parse(row.GetCell(1).StringCellValue),
                        Temperature = ReadDecimal(row.GetCell(2)),
                        RelativeHumidity = ReadUshort(row.GetCell(3)),
                        Td = ReadDecimal(row.GetCell(4)),
                        AtmosphericPressure = ReadUshort(row.GetCell(5)),
                        WindDirection = ReadString(row.GetCell(6)),
                        WindSpeed = ReadUshort(row.GetCell(7)),
                        CloudCover = ReadUshort(row.GetCell(8)),
                        H = ReadUshort(row.GetCell(9)),
                        VV = ReadString(row.GetCell(10)),
                        WeatherPhenomena = ReadString(row.GetCell(11))
                    };
                    records.Add(record);
                }
            }

            return records;
        }

        private ushort? ReadUshort(ICell cell)
        {
            if (CheckForNull(cell)) return null;
            return Convert.ToUInt16(cell.NumericCellValue);
        }

        private decimal? ReadDecimal(ICell cell)
        {
            if (CheckForNull(cell)) return null;
            return Convert.ToDecimal(cell.NumericCellValue);
        }

        private string? ReadString(ICell cell)
        {
            if (CheckForNull(cell)) return null;
            if(cell.CellType == CellType.Numeric) return cell.NumericCellValue.ToString();
            return cell.StringCellValue;
        }

        private bool CheckForNull(ICell cell)
        {
            return (cell == null) || (cell.CellType == CellType.Blank) ||
                (cell.CellType == CellType.String && String.IsNullOrEmpty(cell.StringCellValue.Replace(" ","")));
        }
    }
}
