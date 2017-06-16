using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Card
{
    public Card() { }
    public Card(Card c)
    {
        mCardSprite = c.mCardSprite;
        mGridSprite = c.mGridSprite;
        mName = c.mName;
        mCost = c.mCost;
        mID = c.mID;
        mCanAttack = c.mCanAttack;
        mCanGenerateResources = c.mCanGenerateResources;
        mHasAuraEffect = c.mHasAuraEffect;
        mDamagePerShot = c.mDamagePerShot;
        mResourcesPerSecond = c.mResourcesPerSecond;
        mAttackRange = c.mAttackRange;
        mAuraRange = c.mAuraRange;
        mActionNames = c.mActionNames;
    }


    public Sprite mCardSprite;
    public Sprite mGridSprite;
    public string mName;
    public float mCost;
    public ulong mID;

    public bool mCanAttack;
    public bool mCanGenerateResources;
    public bool mHasAuraEffect;

    public float mDamagePerShot;
    public float mResourcesPerSecond;
    public float mAttackRange;
    public float mAuraRange;

    public List<string> mActionNames;
    public delegate void Action(TowerObject me);
    public List<Action> mActions;

}


