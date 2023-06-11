using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1;
using Attribute = Org.BouncyCastle.Asn1.Cms.Attribute;

namespace LevelUpCenter.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public IActionResult PublicMethohd()
    {
        return new OkResult();
    }

    public AllowAnonymousAttribute(Asn1Sequence seq) : base(seq)
    {
    }

    public AllowAnonymousAttribute(DerObjectIdentifier attrType, Asn1Set attrValues) : base(attrType, attrValues)
    {
    }
}