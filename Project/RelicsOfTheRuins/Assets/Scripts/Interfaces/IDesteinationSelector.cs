using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IDestinationSelector
{
    public Transform SelectDestination();
}
