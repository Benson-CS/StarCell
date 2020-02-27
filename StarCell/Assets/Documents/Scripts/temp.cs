using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
a very dumb thing by the raccoon
      dP                   dP          dP       dP dP       
      88                   88          88       88 88       
.d888b88 88d888b. .d8888b. 88 .d8888b. 88d888b. 88 88  .dP  
88'  `88 88'  `88 88'  `88 88 88'  `"" 88'  `88 88 88888"   
88.  .88 88    88 88.  .88 88 88.  ... 88    88 88 88  `8b. 
`88888P8 dP    dP `8888P88 dP `88888P' dP    dP dP dP   `YP 
                       .88                                  
                   d8888P                                   
*/

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Countdown", 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Countdown()
    {
        Invoke("putyourvoidhere", 0f);
    }
}
