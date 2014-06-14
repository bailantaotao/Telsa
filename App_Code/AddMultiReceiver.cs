using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AddMultiReceiver 的摘要描述
/// </summary>
public class AddMultiReceiver:DecoratorReceiver
{
    public IndexFactory iftory;

    public AddMultiReceiver(IndexFactory iftory)
    {
        this.iftory = iftory;
    }

    public override IndexFactory CopySet()
    {
        this.iftory.countSet.AddRange(iftory.receiverSet);    
            
        return this.iftory;
    }
}