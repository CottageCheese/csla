﻿//-----------------------------------------------------------------------
// <copyright file="Child.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>no summary</summary>
//-----------------------------------------------------------------------

using System;

namespace Csla.Test.FieldManager
{
  [Serializable]
  public class Child : BusinessBase<Child>
  {
    public static Child NewChild(IChildDataPortal<Child> childDataPortal)
    {
      return childDataPortal.CreateChild();
    }

    public static Child GetChild(IChildDataPortal<Child> childDataPortal)
    {
      return childDataPortal.FetchChild();
    }

    public Child()
    {
      MarkAsChild();
    }

    private static PropertyInfo<string> DataProperty = RegisterProperty<string>(typeof(Child), new PropertyInfo<string>("Data"));
    public string Data
    {
      get { return GetProperty<string>(DataProperty); }
      set { SetProperty<string>(DataProperty, value); }
    }

    private static PropertyInfo<string> RootDataProperty = RegisterProperty<string>(typeof(Child), new PropertyInfo<string>("RootData", string.Empty));
    public string RootData
    {
      get { return GetProperty<string>(RootDataProperty); }
      set { SetProperty<string>(RootDataProperty, value); }
    }

    private string _status;
    public string Status
    {
      get { return _status; }
    }

    public void DeleteChild()
    {
      MarkDeleted();
    }

    protected override void Child_Create()
    {
      _status = "Created";
    }

    [FetchChild]
    protected void Child_Fetch()
    {
      _status = "Fetched";
    }

    [InsertChild]
    protected void Child_Insert()
    {
      _status = "Inserted";
    }

    [UpdateChild]
    protected void Child_Update()
    {
      _status = "Updated";
    }

    [DeleteSelfChild]
    protected void Child_DeleteSelf()
    {
      _status = "Deleted";
    }
  }
}