using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms; // 假设 TextBox 来自 Windows Forms
using ClosedXML.Excel;
using Resume.DTO;

namespace Resume.service
{
    class ExcelProcess
    {
        public static string ExportToExcel(List<PersonInfo> persons, string folderPath, TextBox text)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("人员信息");

                // 设置表头（按新顺序）
                worksheet.Cell(1, 1).Value = "序号";
                worksheet.Cell(1, 2).Value = "姓名";
                worksheet.Cell(1, 3).Value = "性别";
                worksheet.Cell(1, 4).Value = "籍贯";
                worksheet.Cell(1, 5).Value = "民族";
                worksheet.Cell(1, 6).Value = "身份证号";
                worksheet.Cell(1, 7).Value = "出生日期";
                worksheet.Cell(1, 8).Value = "生源地";
                worksheet.Cell(1, 9).Value = "政治面貌";
                worksheet.Cell(1, 10).Value = "毕业院校";
                worksheet.Cell(1, 11).Value = "专业";
                worksheet.Cell(1, 12).Value = "专业代码";
                worksheet.Cell(1, 13).Value = "学历学位";
                worksheet.Cell(1, 14).Value = "毕业时间"; // 对应 PersonInfo.DegreeDate
                worksheet.Cell(1, 15).Value = "邮箱";
                worksheet.Cell(1, 16).Value = "手机电话";
                worksheet.Cell(1, 17).Value = "健康情况";
                worksheet.Cell(1, 18).Value = "英语水平";
                worksheet.Cell(1, 19).Value = "求职岗位";

                // 写入数据（按新表头顺序匹配 PersonInfo 属性）
                for (int i = 0; i < persons.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = i + 1;                // 序号
                    worksheet.Cell(i + 2, 2).Value = persons[i].Name;      // 姓名
                    worksheet.Cell(i + 2, 3).Value = persons[i].Gender;    // 性别
                    worksheet.Cell(i + 2, 4).Value = persons[i].NativePlace; // 籍贯
                    worksheet.Cell(i + 2, 5).Value = persons[i].Ethnicity; // 民族
                    worksheet.Cell(i + 2, 6).Value = persons[i].IDNumber;  // 身份证号
                    worksheet.Cell(i + 2, 7).Value = persons[i].BirthDate; // 出生日期
                    worksheet.Cell(i + 2, 8).Value = persons[i].OriginPlace; // 生源地
                    worksheet.Cell(i + 2, 9).Value = persons[i].PoliticalStatus; // 政治面貌
                    worksheet.Cell(i + 2, 10).Value = persons[i].University; // 毕业院校
                    worksheet.Cell(i + 2, 11).Value = persons[i].Major;    // 专业
                    worksheet.Cell(i + 2, 12).Value = persons[i].MajorCode; // 专业代码
                    worksheet.Cell(i + 2, 13).Value = persons[i].Degree;   // 学历学位
                    worksheet.Cell(i + 2, 14).Value = persons[i].DegreeDate; // 毕业时间
                    worksheet.Cell(i + 2, 15).Value = persons[i].Email;    // 邮箱
                    worksheet.Cell(i + 2, 16).Value = persons[i].Phone;    // 手机电话
                    worksheet.Cell(i + 2, 17).Value = persons[i].HealthStatus; // 健康情况
                    worksheet.Cell(i + 2, 18).Value = persons[i].EnglishLevel; // 英语水平
                    worksheet.Cell(i + 2, 19).Value = persons[i].JobPosition; // 求职岗位

                    text.AppendText($"写入 {persons[i].Name} 完成！\r\n");
                }

                // 自动调整列宽
                worksheet.Columns().AdjustToContents();

                // 设置最小列宽（例如 10 个字符宽度）
                double minWidth = 10.0; // 可根据需要调整
                for (int col = 1; col <= 19; col++)
                {
                    var column = worksheet.Column(col);
                    if (column.Width < minWidth)
                    {
                        column.Width = minWidth;
                    }
                }

                // 生成文件名
                string fileName = $"简历汇总_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                string outputPath = Path.Combine(folderPath, fileName);

                // 保存文件
                workbook.SaveAs(outputPath);
                return fileName;
            }
        }
    }
}