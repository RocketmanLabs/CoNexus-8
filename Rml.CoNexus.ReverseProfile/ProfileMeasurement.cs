using System.Drawing;

namespace Rml.CoNexus.ReverseProfile;

public static class ProfileMeasurement
{
    public static double CalculateDistribution(this List<(double X, double Y)> points, Rectangle plane, decimal defaultMax = 100.0m)
    {
        if (points == null || points.Count == 0)
            throw new ArgumentException("The points list cannot be null or empty.");

        // Calculate the centroid of the points
        double centroidX = points.Average(p => p.X);
        double centroidY = points.Average(p => p.Y);

        // Calculate the average distance from each point to the centroid
        double totalDistance = 0;
        foreach (var point in points)
        {
            double distance = Math.Sqrt(Math.Pow(point.X - centroidX, 2) + Math.Pow(point.Y - centroidY, 2));
            totalDistance += distance;
        }

        double averageDistance = totalDistance / points.Count;

        // Normalize the average distance to a range of 0 to 1
        // Assuming the maximum distance any point can be from the centroid (max/2,max/2) is the distance to
        // a corner (0,0) or (100,100)
        double maxDistance = Math.Sqrt(Math.Pow(plane.Width / 2, 2) + Math.Pow(plane.Height / 2, 2));

        double distributionScore = 1 - (averageDistance / maxDistance);
        return distributionScore;
    }
}


