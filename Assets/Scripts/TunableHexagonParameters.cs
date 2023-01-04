using UnityEngine;

public class TunableHexagonParameters
{
    public const float ZERO = 0f;
    public const float HALF = .5f;
    public const float NEGATIVE_HALF = -.5f;
    public const float OUTER_RADIUS = 10f;
    public const float INNER_RADIUS = OUTER_RADIUS * 0.866025404f;
    public const float NEGATIVE_INNER_RADIUS = INNER_RADIUS * -1;
    public const float NEGATIVE_OUTER_RADIUS = OUTER_RADIUS * -1;
   
    public static Vector3[] hexagonCorners = {
        new Vector3(ZERO, ZERO, OUTER_RADIUS),
        new Vector3(INNER_RADIUS, ZERO, HALF * OUTER_RADIUS),
        
        new Vector3(INNER_RADIUS, ZERO, NEGATIVE_HALF * OUTER_RADIUS),
        new Vector3(ZERO, ZERO, NEGATIVE_OUTER_RADIUS),

        new Vector3(NEGATIVE_INNER_RADIUS, ZERO, NEGATIVE_HALF * OUTER_RADIUS),
        new Vector3(NEGATIVE_INNER_RADIUS, ZERO, HALF * OUTER_RADIUS)
    };

}
