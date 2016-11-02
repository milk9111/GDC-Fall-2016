using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletCache : MonoBehaviour {
    public static BulletCache activeCache;

    [System.Serializable]
    public class CacheDetails {
        public GameObject bulletToStore;
        public int numberOfBullets;
    }

    public CacheDetails[] enemyBulletTypes;
    public CacheDetails[] playerBulletTypes;

    private List<Queue<GameObject>> enemyBullets;
    private List<Queue<GameObject>> playerBullets;

    public Transform playerBulletsStorage;
    public Transform enemyBulletsStorage;
    
    void Awake() {
        enemyBullets = new List<Queue<GameObject>>();

        playerBullets = new List<Queue<GameObject>>();

        restockBullets(0);

        activeCache = this;
    }

    public void restockBullets(int num) {
        // As bullets are consumed, they should be re-added. If we ever run low, grab an extra set:
        int i = 0;
        foreach (CacheDetails cache in enemyBulletTypes) {
            if (enemyBullets.Count <= i) {
                enemyBullets.Add(new Queue<GameObject>());
            }
            int bulletsToCreate = cache.numberOfBullets;
            if (num != 0) {
                bulletsToCreate = num;
            }
            for (int count = 0; count < bulletsToCreate; count++) {
                GameObject newBullet = Instantiate(cache.bulletToStore);
                newBullet.transform.SetParent(enemyBulletsStorage);
                newBullet.SetActive(false);
                enemyBullets[i].Enqueue(newBullet);
            }
            i++;
        }
        i = 0;
        foreach (CacheDetails cache in playerBulletTypes) {
            if (playerBullets.Count <= i) {
                playerBullets.Add(new Queue<GameObject>());
            }
            int bulletsToCreate = cache.numberOfBullets;
            if (num != 0) {
                bulletsToCreate = num;
            }
            for (int count = 0; count < bulletsToCreate; count++) {
                GameObject newBullet = Instantiate(cache.bulletToStore);
                newBullet.transform.SetParent(playerBulletsStorage);
                newBullet.SetActive(false);
                playerBullets[i].Enqueue(newBullet);
            }
            i++;
        }
    }

    public GameObject getEnemyBullet(int bulletType, Vector3 position, Quaternion rotation) {
        return getBulletHelper(enemyBullets, bulletType, position, rotation);
    }

    public GameObject getPlayerBullet(int bulletType, Vector3 position, Quaternion rotation) {
        return getBulletHelper(playerBullets, bulletType, position, rotation);
    }

    private GameObject getBulletHelper(List<Queue<GameObject>> list, int bulletType, Vector3 position, Quaternion rotation) {
        if (list[bulletType].Count == 0) {
            restockBullets(30);
        }
        GameObject bullet = list[bulletType].Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        return bullet;

    }

    public void requeueBullet(GameObject bulletObject, bool playerBullet = false) {
        CacheDetails[] theCache = enemyBulletTypes;
        List<Queue<GameObject>> theList = enemyBullets;
        if (playerBullet) {
            theCache = playerBulletTypes;
            theList = playerBullets;
        }
        for (int i = 0; i < theCache.Length; i++) {
            if (theCache[i].bulletToStore.GetType() == bulletObject.GetType()) {
                bulletObject.SetActive(false);
                theList[i].Enqueue(bulletObject);
                return;
            }
        }
        // If we're here, this wasn't a cached bullet. Destroy it.
        Destroy(bulletObject);
    }

}
