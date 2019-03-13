using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    public interface Slide
    {
        //Override this to fill the scene with the appropriate slide info

        void fillScene(GameObject gameObject);
      
    }
}
