using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntVector2
{
    public int x = -1;
    public int y = -1;
    public IntVector2() { x = -1; y = -1; }
    public IntVector2(int _x, int _y) { x = _x; y = _y; }

    int sqrMagnitude
    {
        get { return x * x + y * y; }
    }

    public static bool operator ==(IntVector2 a, IntVector2 b)
    {
        if ((object)a == null && (object)b == null)
        {
            return true;
        }
        if ((object)a == null)
        {
            return false;
        }
        if ((object)a == null)
        {
            return false;
        }
        return (a.x == b.x && a.y == b.y);
    }
    public static bool operator !=(IntVector2 a, IntVector2 b)
    {
        return (a.x != b.x || a.y != b.y);
    }

    public bool Equals(IntVector2 b)
    {
        return (this == b);
    }

    public override string ToString()
    {
        return "(" + x.ToString() + ", " + y.ToString() + ")";
    }
}

public class TileClass
{
    public GameObject gameObject;
    public int distance;

}

public class GridManager : MonoBehaviour {


    public GameObject baseTile;
    public float mTileSize = 0.25f;
    public int mTileCount = 20;
    public Vector2 mCenter = new Vector2(0,0);
    public List<List<TileClass>> mTiles = new List<List<TileClass>> ();
    public GameObject mTowerPrefab = null;

    public CardManager mCardManager = null;

    protected GameObject mStart = null;
    protected GameObject mEnd = null;

    public GameObject mStartTilePrefab = null;
    public GameObject mEndTilePrefab = null;

    public bool IntVecListContains(List<IntVector2> list, IntVector2 target)
    {
        for (int i = 0; i < list.Count; ++i) if (list[i] == target) return true;
        return false;
    }

    // Use this for initialization
    void Start () {
        CreateGrid();
	}

    void CreateGrid()
    {
        int i = 0;
        for (float x = mCenter.x - (mTileCount * mTileSize) / 2; x < mCenter.x + (mTileCount * mTileSize) / 2; x += mTileSize)
        {
            mTiles.Add(new List<TileClass>());
            for (float y = mCenter.y - (mTileCount * mTileSize) / 2; y < mCenter.y + (mTileCount * mTileSize) / 2; y += mTileSize) {
                GameObject obj = Instantiate<GameObject>(baseTile);
                obj.transform.position = new Vector3(x, y, 0);
                obj.GetComponent<TileObject>().x = i;
                obj.GetComponent<TileObject>().y = mTiles[i].Count;
                obj.GetComponent<TileObject>().mGridManager = this;
                TileClass t = new TileClass();
                t.gameObject = obj;
                t.distance = 0;
                mTiles[i].Add(t);
            }
            ++i;
        }
        float
            startX = (mCenter.x + (mTileCount * mTileSize) / 2),
            startY = (mCenter.y + (mTileCount * mTileSize) / 2) - mTileSize,
            endX =   (mCenter.x - (mTileCount * mTileSize) / 2) - mTileSize,
            endY =   (mCenter.y - (mTileCount * mTileSize) / 2);
        mStart = Instantiate<GameObject>(mStartTilePrefab, new Vector3(startX, startY, 0), Quaternion.identity);
        mStart.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        mEnd = Instantiate<GameObject>(mEndTilePrefab, new Vector3(endX, endY, 0), Quaternion.identity);
        mEnd.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);

        GetPathToEnd();
    }

    public List<Vector2> GetPathToEnd()
    {
        List<IntVector2> gridPath = new List<IntVector2>();
        List<Vector2> actualCoordPath = new List<Vector2>();

        Debug.Log("GETTING PATH");
        gridPath.Add(new IntVector2( 19,19));
        bool pathFound = recursivePathFind(new IntVector2(19,19), new IntVector2(0, 0), new List<IntVector2>(), gridPath);
        if (pathFound)
        {
            Debug.Log("PATH FOUND");
            for (int x = 0; x < mTiles.Count; ++x) for (int y = 0; y < mTiles[x].Count; ++y)
                {
                    mTiles[x][y].distance = 0;
                    mTiles[x][y].gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                }
            for (int i = 0; i < gridPath.Count; ++i)
            {
                mTiles[gridPath[i].x][gridPath[i].y].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                actualCoordPath.Add(mTiles[gridPath[i].x][gridPath[i].y].gameObject.transform.position);
            }

        }
        else Debug.Log("I gave up");
        return actualCoordPath;
    }

    bool recursivePathFind(IntVector2 currentPos, IntVector2 endPos, List<IntVector2> path, List<IntVector2> bestPath)
    {
        if (currentPos == endPos) {
            if(path.Count < bestPath.Count)
            {
                bestPath = path;
            }
            return true;
        }
        if (path.Count > 0 && bestPath.Count > 0 && path.Count >= bestPath.Count) return false;
        if (path.Count > 0 && bestPath.Count > 0 && mTiles[currentPos.x][currentPos.y].distance >= path.Count) return false;
        mTiles[currentPos.x][currentPos.y].distance = path.Count;
        Debug.Log("LOOKING FOR PATH " + currentPos.ToString() + " " + endPos.ToString() );

        mTiles[currentPos.x][currentPos.y].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);


        IntVector2 p = new IntVector2(currentPos.x, currentPos.y);
        IntVector2 def = new IntVector2();

        p.x = currentPos.x - 1;
        p.y = currentPos.y;
        //Debug.Log("_______________________________________________________________________________");
        //Debug.Log("Current path is: ");
        //for(int i = 0; i < path.Count; ++i)
        //{
        //    Debug.Log(path[i]);
        //}
        Debug.Log("Checking left point " + p + " in grid. I can place: " + IsEmpty(p.x, p.y) + " And this does exist in the path already: " + IntVecListContains(path, p));
        if (IsEmpty(p.x, p.y) && IntVecListContains(path, p) == false)
        {
            Debug.Log("Left");
            //Debug.Log("CHECKING A THING");
            path.Add(p);
            if (recursivePathFind(new IntVector2(p.x, p.y), endPos, path, bestPath)) return true;
            path.RemoveAt(path.Count - 1);
        }

        p.x = currentPos.x;
        p.y = currentPos.y - 1;
        Debug.Log("Checking down point " + p + " in grid. I can place: " + IsEmpty(p.x, p.y) + " And this does exist in the path already: " + IntVecListContains(path, p));
        if (IsEmpty(p.x, p.y) && IntVecListContains(path, p) == false)
        {
            Debug.Log("down");
            //Debug.Log("CHECKING A THING");
            path.Add(p);
            if (recursivePathFind(p, endPos, path, bestPath)) return true;
            path.RemoveAt(path.Count - 1);
        }

        p.x = currentPos.x + 1;
        p.y = currentPos.y;
        Debug.Log("Checking right point " + p + " in grid. I can place: " + IsEmpty(p.x, p.y) + " And this does exist in the path already: " + IntVecListContains(path, p));
        if (IsEmpty(p.x, p.y) && IntVecListContains(path, p) == false)
        {
            Debug.Log("Right");
            //Debug.Log("CHECKING A THING");
            path.Add(p);
            if (recursivePathFind(p, endPos, path, bestPath)) return true;
            path.RemoveAt(path.Count - 1);
        }

        p.x = currentPos.x;
        p.y = currentPos.y + 1;
        Debug.Log("Checking up point " + p + " in grid. I can place: " + IsEmpty(p.x, p.y) + " And this does exist in the path already: " + IntVecListContains(path, p));
        if (IsEmpty(p.x, p.y) && IntVecListContains(path, p) == false)
        {
            Debug.Log("up");
            //Debug.Log("CHECKING A THING");
            path.Add(p);
            if (recursivePathFind(p, endPos, path, bestPath)) return true;
            path.RemoveAt(path.Count - 1);
        }
        return false;
    }

    private bool Find(IntVector2 obj)
    {
        throw new NotImplementedException();
    }

    private bool IsEmpty(int x, int y)
    {
        return (x < mTiles.Count && y < mTiles[0].Count && x >= 0 && y >= 0 && mTiles[x][y].gameObject.transform.childCount == 0);
    }

    public void Clicked(TileObject tile)
    {
        if (mCardManager.mSelected)
        {
            if (tile.gameObject.transform.childCount == 0)
            {
                PlaceObject(tile.x, tile.y, mCardManager.mSelected.GetComponent<CardObject>().me);
            }
        }
    }

    public bool CanPlace(int x, int y)
    {
        bool canPlace = false;
        if(IsEmpty(x,y))
        {
            GameObject temp = Instantiate<GameObject>(mTowerPrefab);
            temp.transform.parent = mTiles[x][y].gameObject.transform;
            if(GetPathToEnd().Count > 0)
            {
                canPlace = true;
            }

            //mTiles[x][y].transform.DetachChildren();
            Destroy(temp);
        }
        return canPlace;
    }

    public void PlaceObject(int x, int y, Card c )
    {
        if (!CanPlace(x, y)) return;
        GameObject obj = Instantiate<GameObject>(mTowerPrefab);
        obj.GetComponent<TowerObject>().Load(c);
        obj.transform.parent = mTiles[x][y].gameObject.transform;
        obj.transform.position = obj.transform.parent.transform.position + (new Vector3(0, 0, -0.5f));
        mCardManager.CardPlaced();


        GetPathToEnd();
        //mTiles[x][y] = Instantiate<GameObject>(c.mBaseObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
