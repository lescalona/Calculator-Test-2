using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Calculator.WindowsUi.Common.Attributes;

namespace AadiCapif.Sci.WindowsUi.Common
{
    public static class DataGridViewFluidExtensions
    {
        public static DataGridViewColumn AsReadonly(this DataGridViewColumn source)
        {
            source.ReadOnly = true;
            return source;
        }

        public static DataGridViewColumn AsHidden(this DataGridViewColumn source)
        {
            source.Visible = false;
            return source;
        }

        public static DataGridViewColumn AsFrozen(this DataGridViewColumn source)
        {
            source.Frozen = true;
            return source;
        }

        public static DataGridViewColumn AsSortable(this DataGridViewColumn source)
        {
            source.SortMode = DataGridViewColumnSortMode.Programmatic;
            return source;
        }
        public static DataGridViewColumn AsSmallColumn(this DataGridViewColumn source)
        {
            source.Width = 50;
            return source;
        }
        public static DataGridViewColumn SetDisplayName<T>(this DataGridViewColumn source, string aditionals = "")
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrEmpty(source.DataPropertyName))
            {
                return source;
            }
            var propertyInfo = TypeDescriptor.GetProperties(typeof(T))[source.DataPropertyName];

            var displayName = propertyInfo.DisplayName + " " + aditionals;
            source.HeaderText = displayName;
            return source;
        }
        public static DataGridViewColumn SetDisplayName(this DataGridViewColumn source, string displayName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            source.HeaderText = displayName;
            return source;
        }
        public static DataGridViewColumn SetDataPropertyName(this DataGridViewColumn source, string dataPropertyName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            source.DataPropertyName = dataPropertyName;
            return source;
        }

        public static DataGridViewColumn With(this DataGridViewColumn source, Action<DataGridViewColumn> setting)
        {
            if (setting == null)
            {
                return source;
            }
            setting(source);
            return source;
        }

        public static DataGridView BindSource<TModel, TElement>(this DataGridView control, TModel model, Expression<Func<TModel, IEnumerable<TElement>>> dataSource)
        {
            control.DataSource = dataSource.Compile().Invoke(model);
            return control;
        }

        public static DataGridViewColumn Bind<TItemModel>(this DataGridViewColumn source, Expression<Func<TItemModel, object>> value, Func<string, string> displayNameModifier = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            var displayMod = displayNameModifier ?? (x => x);
            var propName = GetPlainPropertyName(source, value);
            var propertyDescriptor = TypeDescriptor.GetProperties(typeof(TItemModel))[propName];
            if (string.IsNullOrEmpty(source.HeaderText))
            {
                source.HeaderText = displayMod(propertyDescriptor.DisplayName);
            }
            source.DataPropertyName = propertyDescriptor.Name;
            source.ValueType = propertyDescriptor.PropertyType;
            source.ReadOnly = propertyDescriptor.IsReadOnly;

            var dataaFormat = propertyDescriptor.Attributes.OfType<DisplayFormatAttribute>().FirstOrDefault();
            if (dataaFormat != null)
            {
                source.DefaultCellStyle.Format = dataaFormat.DataFormatString;
            }
            var visibleAttribute = propertyDescriptor.Attributes.OfType<HiddenAttribute>().FirstOrDefault();
            if (visibleAttribute != null)
            {
                source.Visible = visibleAttribute.Visible;
            }
            return source;
        }

        private static string GetPlainPropertyName<TModel>(DataGridViewColumn control, Expression<Func<TModel, object>> expression)
        {
            MemberExpression memberExpression = null;

            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new NotSupportedException($"Expresión de Bind DataGridViewColumn control ({control.Name}) no suportada.");
            }
            return memberExpression.Member.Name;
        }
    }
}