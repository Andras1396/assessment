package MvvmCross.Droid.Support.V7.RecyclerView;

import android.content.Context;
import android.support.annotation.Nullable;
import android.support.v7.widget.RecyclerView;
import android.util.AttributeSet;

public class MvxRecyclerView extends RecyclerView {
    public MvxRecyclerView(Context context) {
        super(context);
    }

    public MvxRecyclerView(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    public MvxRecyclerView(Context context, @Nullable AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }
}
