package MvvmCross.Platforms.Android.Binding.Views;

import android.content.Context;
import android.support.annotation.Nullable;
import android.util.AttributeSet;
import android.widget.ListView;
import android.widget.Spinner;

public class MvxSpinner extends Spinner {
    public MvxSpinner(Context context) {
        super(context);
    }

    public MvxSpinner(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    public MvxSpinner(Context context, @Nullable AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }
}
