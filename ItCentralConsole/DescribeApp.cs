// See https://aka.ms/new-console-template for more information
using System.Buffers;

public class DescribeApp
{
    public string Name { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public Owner owner { get; set; }
    public string html_url { get; set; }
}