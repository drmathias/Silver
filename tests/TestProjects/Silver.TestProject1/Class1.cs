﻿using Stratis.SmartContracts;

public class We : SmartContract
{
    public We(ISmartContractState state) : base(state) { }
    public int Add(int a, int b)
    {
        //var x = new string("ll".ToCharArray());
        //var xx = new string[] { "foo" };
        return a + b; 
    }

    private int testField = 0;
}
