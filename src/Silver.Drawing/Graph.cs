﻿namespace Silver.Drawing;

using System.DrawingCore;
using System.DrawingCore.Drawing2D;
using System.DrawingCore.Imaging;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Layout.Layered;
using Microsoft.Msagl.Drawing;

using Node = Microsoft.Msagl.Drawing.Node;
using Edge = Microsoft.Msagl.Drawing.Edge;
using GeometryNode = Microsoft.Msagl.Core.Layout.Node;
using GeometryEdge = Microsoft.Msagl.Core.Layout.Edge;
using GeometryPoint = Microsoft.Msagl.Core.Geometry.Point;

using AGL.Drawing.Gdi;
public class Graph : Runtime 
{
    public static void Draw(Microsoft.Msagl.Drawing.Graph graph, string filename, GraphFormat format, int width = 2000, int height = 2000)
    {
        graph.GeometryGraph = new GeometryGraph(); 
        var layout = GetSugiyamaLayout(5, 10);
        graph.LayoutAlgorithmSettings = layout;
        foreach (Node n in graph.Nodes)
        {
            var gn = new GeometryNode(CurveFactory.CreateRectangle(200, 40, new GeometryPoint()), n);
            graph.GeometryGraph.Nodes.Add(gn);
            n.GeometryNode = gn;
        }
        foreach (Edge edge in graph.Edges)
        {
            var sn = graph.FindGeometryNode(edge.Source);
            var tn = graph.FindGeometryNode(edge.Target);
            var ge = new GeometryEdge(sn, tn);
            ge.UserData = edge;
            ge.EdgeGeometry.TargetArrowhead = new Arrowhead();
            graph.GeometryGraph.Edges.Add(ge);
            edge.GeometryEdge = ge;
        }
        graph.GeometryGraph.UpdateBoundingBox();
        new LayeredLayout(graph.GeometryGraph, layout).Run();

        using Bitmap bmp = new Bitmap(width, height);
        using Graphics g = Graphics.FromImage(bmp);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.Clear(System.DrawingCore.Color.White);
        Rectangle rect = new Rectangle(0, 0, width, height);
        
        GdiUtils.SetGraphTransform(graph.GeometryGraph, rect, g);
        WarnIfFileExists(filename);
        switch (format)
        {
            case GraphFormat.BMP:
                GdiUtils.Draw2(rect, graph, graph.GeometryGraph, g);
                bmp.Save(filename, ImageFormat.Bmp);
                Info("Saved graph to BMP file {0}.", filename);
                break;

            case GraphFormat.PNG:
                GdiUtils.Draw2(rect, graph, graph.GeometryGraph, g);
                bmp.Save(filename, ImageFormat.Png);
                Info("Saved graph to PNG file {0}.", filename);
                break;

            case GraphFormat.DOT:
                File.WriteAllText(filename, DOTWriter.Write(graph));
                Info("Saved graph to DOT file {0}.", filename);
                break;

            case GraphFormat.DGML:
                File.WriteAllText(filename, DGMLWriter.Write(graph));
                Info("Saved graph to DGML file {0}.", filename);
                break;

            case GraphFormat.SVG:
                using (var fsvg = new FileStream(filename, FileMode.Create))
                {
                    var svgWriter = new SvgGraphWriter(fsvg, graph);
                    svgWriter.Write();
                    Info("Saved graph to SVG file {0}.", filename);
                }
                break;

            case GraphFormat.XML:
                using (var fxml = new FileStream(filename, FileMode.Create))
                {
                    var xmlWriter = new GraphWriter(fxml, graph);
                    xmlWriter.Write();
                    Info("Saved graph to XML file {0}.", filename);
                }
                break;
        }        
    }

    public static SugiyamaLayoutSettings GetSugiyamaLayout(int minNodeWidth = 20, int minNodeHeight = 10)
    {
        SugiyamaLayoutSettings sugiyamaSettings = new SugiyamaLayoutSettings
        {
            Transformation = PlaneTransformation.Rotation(Math.PI / 2),
            EdgeRoutingSettings = { EdgeRoutingMode = EdgeRoutingMode.SugiyamaSplines },
            MinNodeHeight = minNodeHeight,
            MinNodeWidth = minNodeWidth

        };
        return sugiyamaSettings;
    }

    public static Microsoft.Msagl.Drawing.Graph FromDot(string dot) => Dot2Graph.Parser.Parse(dot.ToStream(), out var line, out var col, out var msg);
}
