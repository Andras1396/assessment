package MvvmCross.Platforms.Android.Binding.Views;

import android.content.Context;
import android.support.annotation.Nullable;
import android.util.AttributeSet;
import android.widget.ListView;

public class MvxListView extends ListView {
    public MvxListView(Context context) {
        super(context);
    }

    public MvxListView(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    public MvxListView(Context context, @Nullable AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }
}
