using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClosestPair
{
  class PointPair
  {
   
    public Point P1 { get; set; } 
    public Point P2 { get; set; }
    public double Dist { get; set; }

    public PointPair(Point p1, Point p2, double dist) // 생성자
    {
      P1 = p1;
      P2 = p2;
      Dist = dist;
    }
  }
  //class PointPair2
  //{
  //  private Point p1;
  //  private Point p2;
  //  private double dist;

  //  public void GetP1() {

  //  };
  //  public void SetP1();
  //  public PointPair2(Point p1, Point p2, double dist) // 생성자
  //  {
  //    this.p1 = p1;
  //    this.p2 = p2;
  //    this.dist = dist;
  //  }
  //}
}
