using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Utility
{
    public class ExpressionUtility
    {
        public static Expression<Func<TEntity, bool>> BuildEqual<TEntity>(string propertyName, object value) where TEntity : class
        {
            Expression<Func<TEntity, bool>> m_Expression = null;

            var m_TypeEntity = typeof(TEntity);
            var m_ParameterEntity = Expression.Parameter(m_TypeEntity, "e");
            var m_Property = Expression.Property(m_ParameterEntity, propertyName);
            var m_ConstantFalse = Expression.Constant(false);
            m_Expression = Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(m_Property, m_ConstantFalse), new[] { m_ParameterEntity });

            return m_Expression;
        }
        public static Expression<Func<TTarget, bool>> Transform<TSource, TTarget>(Expression<Func<TSource, bool>> expression)
        {
            Expression<Func<TTarget, bool>> m_Expression = null;

            //parameter that will be used in generated expression
            var param = Expression.Parameter(typeof(TTarget));
            //visiting body of original expression that gives us body of the new expression
            var body = new Visitor<TTarget>(param).Visit(expression.Body);
            //generating lambda expression form body and parameter 
            //notice that this is what you need to invoke the Method_2
            m_Expression = Expression.Lambda<Func<TTarget, bool>>(body, param);

            return m_Expression;
        }
        public static PropertyInfo GetPropertyName<T>(System.Linq.Expressions.Expression<Func<T, object>> property)
        {
            System.Linq.Expressions.LambdaExpression lambda = (System.Linq.Expressions.LambdaExpression)property;
            System.Linq.Expressions.MemberExpression memberExpression;

            if (lambda.Body is System.Linq.Expressions.UnaryExpression)
            {
                System.Linq.Expressions.UnaryExpression unaryExpression = (System.Linq.Expressions.UnaryExpression)(lambda.Body);
                memberExpression = (System.Linq.Expressions.MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (System.Linq.Expressions.MemberExpression)(lambda.Body);
            }

            return ((PropertyInfo)memberExpression.Member);
        }
    }

    public class Visitor<T> : ExpressionVisitor
    {
        ParameterExpression _parameter;

        //there must be only one instance of parameter expression for each parameter 
        //there is one so one passed here
        public Visitor(ParameterExpression parameter)
        {
            _parameter = parameter;
        }

        //this method replaces original parameter with given in constructor
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }

        //this one is required because PersonData does not implement IPerson and it finds
        //property in PersonData with the same name as the one referenced in expression 
        //and declared on IPerson
        protected override Expression VisitMember(MemberExpression node)
        {
            Expression m_Expression = null;

            //only properties are allowed if you use fields then you need to extend
            // this method to handle them
            if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
                m_Expression = base.VisitMember(node);
            else
            {
                //name of a member referenced in original expression in your 
                //sample Id in mine Prop
                var memberName = node.Member.Name;
                //find property on type T (=PersonData) by name
                var otherMember = typeof(T).GetProperty(memberName);
                //visit left side of this expression p.Id this would be p
                var inner = Visit(node.Expression);
                m_Expression = Expression.Property(inner, otherMember);
            }

            return m_Expression;
        }
    }
}
